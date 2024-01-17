using MediatR;
using PermissionPaladin.Application.Shared;

namespace PermissionPaladin.Application.Users.Queries.SIgnIn;

public record SignInQuery(string UserName, string Password) : IRequest<HttpResult>;
