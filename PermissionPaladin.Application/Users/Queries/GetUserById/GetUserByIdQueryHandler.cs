using MediatR;
using Microsoft.AspNetCore.Identity;
using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly UserManager<User> _userManager;

    public GetUserByIdQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.FindByIdAsync(request.UserId.ToString());
    }
}
