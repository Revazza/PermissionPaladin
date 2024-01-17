using MediatR;
using Microsoft.AspNetCore.Mvc;
using PermissionPaladin.Application.Users.Queries.SIgnIn;

namespace PermissionPaladin.Api.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(SignInQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

}
