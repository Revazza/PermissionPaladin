using PermissionPaladin.Infrastructure.Enum;

namespace PermissionPaladin.Infrastructure.Caching.Interfaces;

public interface ICacheableQuery
{
    string SectionName { get; }
    string Salt { get; set; }
}
