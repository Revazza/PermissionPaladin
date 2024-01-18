using Microsoft.AspNetCore.Mvc;
using PermissionPaladin.Application.Authentication.Attributes;
using PermissionPaladin.Domain.Enums;

namespace PermissionPaladin.Api.Controllers;
[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok("");
    }

    [HasPermission(AccessPermissions.AddProduct)]
    [HttpPost]
    public async Task<IActionResult> AddProduct()
    {
        return Ok("");
    }

}
