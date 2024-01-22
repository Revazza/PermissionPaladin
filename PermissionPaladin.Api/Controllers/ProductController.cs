using MediatR;
using Microsoft.AspNetCore.Mvc;
using PermissionPaladin.Application.Authentication.Attributes;
using PermissionPaladin.Domain.Enums;

namespace PermissionPaladin.Api.Controllers;
[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISender _mediator;

    public ProductController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(AccessPermissions.AddProduct)]
    [HttpPost]
    public async Task<IActionResult> AddProduct()
    {
        return Ok("");
    }

}
