using MediatR;
using PermissionPaladin.Infrastructure.Shared.HttpResults;
using PermissionPaladin.Persistance.Repositories.Interfaces;
using PermissionPaladin.Persistance.Services;
using PermissionPaladin.Persistance.Services.Interfaces;

namespace PermissionPaladin.Application.Admins.Commands.AddToRole;

public record AddToRoleCommand(int UserId, string RoleName) : IRequest<Result>;

public class AddToRoleCommandHandler : IRequestHandler<AddToRoleCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddToRoleCommandHandler(
        IRoleRepository roleRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddToRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdWithRolesAsync(request.UserId);

        if (user is null)
        {
            return Result.NotOk("User doesn't exist");
        }

        var role = await _roleRepository.GetByNameAsync(request.RoleName);

        if (role is null)
        {
            return Result.NotOk("Role doesn't exist");
        }

        if (user.IsInRole(role))
        {
            return Result.NotOk($"User already in role {role.Name}");
        }

        user.AddToRole(role);

        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok($"User added to role {role.Name}");
    }

}
