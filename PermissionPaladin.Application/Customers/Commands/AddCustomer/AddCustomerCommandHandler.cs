using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Users;
using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Infrastructure.Shared.HttpResults;

namespace PermissionPaladin.Application.Customers.Commands.AddCustomer;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Result>
{
    private readonly UserManager<User> _userManager;

    public AddCustomerCommandHandler(
        UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        await EnsureNoDuplicateUsernameExistsAsync(request.UserName);
        var customer = await CreateCustomerAsync(request);
        await AddCustomerToRoleAsync(customer);
        return Result.Ok(customer);
    }

    private async Task AddCustomerToRoleAsync(Customer customer)
    {
        var result = await _userManager.AddToRoleAsync(customer, RolesProvider.Customer.Name!);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }

    private async Task<Customer> CreateCustomerAsync(AddCustomerCommand request)
    {
        var customer = new Customer { UserName = request.UserName, NickName = request.NickName };
        var result = await _userManager.CreateAsync(customer, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        return customer;
    }

    private async Task EnsureNoDuplicateUsernameExistsAsync(string userName)
    {
        var userWithSameUsername = await _userManager.FindByNameAsync(userName);
        if (userWithSameUsername is not null)
        {
            throw new Exception("User with given username already exists");
        }
    }

}
