using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionPaladin.Domain.Users;
using System.Security.Cryptography;

namespace PermissionPaladin.Persistance.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(user => user.Roles)
            .WithMany(role => role.Users);

        builder.HasData(SeedUser());
    }

    private static User SeedUser()
    {
        return new User
        {
            Id = 1,
            UserName = "sandro",
            Email = "srevaza1236@gmail.com",
            PasswordHash = HashPassword("sandro1234"),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            NormalizedEmail = "SREVAZA1236@GMAIL.COM",
            NormalizedUserName = "SANDRO",
            PhoneNumber = "1234567890",
        };
    }

    private static string HashPassword(string password)
    {
        byte[] salt;
        byte[] buffer2;
        if (password == null)
        {
            throw new ArgumentNullException("Password not provided");
        }
        using var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8);
        salt = bytes.Salt;
        buffer2 = bytes.GetBytes(0x20);
        byte[] dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
        return Convert.ToBase64String(dst);
    }


}
