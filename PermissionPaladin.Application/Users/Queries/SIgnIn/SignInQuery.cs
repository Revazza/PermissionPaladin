using MediatR;
using PermissionPaladin.Infrastructure.Shared.HttpResults;

namespace PermissionPaladin.Application.Users.Queries.SIgnIn;

public record SignInQuery(string UserName, string Password) : IRequest<Result>;
