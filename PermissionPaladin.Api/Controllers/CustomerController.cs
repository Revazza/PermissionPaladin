using MediatR;
using Microsoft.AspNetCore.Mvc;
using PermissionPaladin.Application.Customers.Commands.AddCustomer;

namespace PermissionPaladin.Api.Controllers;
[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ISender _mediator;

    public CustomerController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(AddCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok();
    }

}
