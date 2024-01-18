using PermissionPaladin.Infrastructure.Enum;

namespace PermissionPaladin.Infrastructure.Caching.Interfaces;

public interface ICachingService
{
    TData? GetData<TData>(string key);
    bool SetData<TData>(string key, TData data, CacheDuration duration = CacheDuration.OneMinute);
}
