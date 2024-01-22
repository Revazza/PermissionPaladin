using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionPaladin.Application.Authentication.Attributes;
using PermissionPaladin.Application.Customers.Commands.AddCustomer;
using PermissionPaladin.Application.Customers.Dtos;
using PermissionPaladin.Application.Customers.Queries.GetCustomerById;
using PermissionPaladin.Application.Services;
using PermissionPaladin.Domain.Enums;

namespace PermissionPaladin.Api.Controllers;
[Route("api/customers")]
[ApiController]
[HasPermission(AccessPermissions.AccessCustomerMenu)]
public class CustomerController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IUserService _userService;

    public CustomerController(ISender mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> AddCustomer(AddCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomer()
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(_userService.GetCurrentUserId()));
        return Ok(result.Adapt<CustomerDto>());
    }

}
