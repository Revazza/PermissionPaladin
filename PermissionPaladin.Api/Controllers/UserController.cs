using MediatR;
using Microsoft.AspNetCore.Mvc;
using PermissionPaladin.Application.Authentication.Attributes;
using PermissionPaladin.Application.Permissions.Queries.GetUserPermissions;
using PermissionPaladin.Application.Services;
using PermissionPaladin.Domain.Enums;

namespace PermissionPaladin.Api.Controllers;
[Route("api/users")]
[ApiController]
[HasPermission(AccessPermissions.AccessUserMenu)]
public class UserController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IUserService _userService;

    public UserController(ISender mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [HttpGet("permissions")]
    public async Task<IActionResult> GetUserPermissions()
    {
        var result = await _mediator.Send(new GetUserPermissionsQuery(_userService.GetCurrentUserId()));
        return Ok(result);
    }

}
