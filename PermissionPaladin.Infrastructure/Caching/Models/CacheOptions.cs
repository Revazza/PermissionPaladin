using PermissionPaladin.Infrastructure.Enum;

namespace PermissionPaladin.Infrastructure.Caching.Models;

public class CacheOptions
{
    public string Key { get; set; }
    public CacheDuration Duration { get; set; }

    public CacheOptions()
    {
        Key = string.Empty;
    }
}
