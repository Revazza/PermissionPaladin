using MediatR;
using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Application.Users.Queries.GetUserById;

public record GetUserByIdQuery(int UserId) : IRequest<User?>;
