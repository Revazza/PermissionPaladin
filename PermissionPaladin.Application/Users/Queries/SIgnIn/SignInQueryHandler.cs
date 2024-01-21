using MediatR;
using Microsoft.AspNetCore.Identity;
using PermissionPaladin.Application.Authentication.Services;
using PermissionPaladin.Domain.Users;
using PermissionPaladin.Infrastructure.Shared.HttpResults;

namespace PermissionPaladin.Application.Users.Queries.SIgnIn;

public class SignInQueryHandler : IRequestHandler<SignInQuery, Result>
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public SignInQueryHandler(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user is null)
        {
            return Result.NotOk("User doesn't exist");
        }

        var isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isCorrectPassword)
        {
            return Result.NotOk("Invalid credentials");
        }

        var token = _jwtTokenGenerator.Generate(user);

        return Result.Ok(token);
    }
}
