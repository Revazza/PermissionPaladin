using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Users;
using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Domain.Users.Managers;

namespace PermissionPaladin.Persistance.Context;
public class PermissionPaladinDbContext : IdentityDbContext<User, Role, int>
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Manager> Manager { get; set; }

}
