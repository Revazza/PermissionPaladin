using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Users;
using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Domain.Users.Managers;

namespace PermissionPaladin.Persistance.Context;
public class PermissionPaladinDbContext : IdentityDbContext<User, Role, int>
{
    public const string SectionName = "PermissionPaladinConnection";
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Manager> Manager { get; set; }

    public PermissionPaladinDbContext(
        DbContextOptions<PermissionPaladinDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Apply all the configurations defined in Configurations folder
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionPaladinDbContext).Assembly);

    }


}
