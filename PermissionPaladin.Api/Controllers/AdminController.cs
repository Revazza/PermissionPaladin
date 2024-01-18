using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionPaladin.Application.Admins.Commands.AddToRole;
using PermissionPaladin.Application.Authentication.Attributes;
using PermissionPaladin.Domain.Enums;

namespace PermissionPaladin.Api.Controllers;
[Route("api/admins")]
[ApiController]
[HasPermission(AccessPermissions.AccessAdminMenu)]
public class AdminController : ControllerBase
{
    private readonly ISender _mediator;

    public AdminController(ISender mediator)
    {
        _mediator = mediator;
    }


    [AllowAnonymous]
    [HttpPost("add-to-role")]
    public async Task<IActionResult> AddToRole(AddToRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}
