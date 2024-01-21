using MediatR;
using PermissionPaladin.Infrastructure.Shared.HttpResults;

namespace PermissionPaladin.Application.Customers.Commands.AddCustomer;

public record AddCustomerCommand(string UserName, string NickName, string Password) : IRequest<Result>;
