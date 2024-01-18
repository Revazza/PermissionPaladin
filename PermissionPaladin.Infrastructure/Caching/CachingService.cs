using Microsoft.Extensions.Caching.Memory;
using PermissionPaladin.Infrastructure.Caching.Interfaces;
using PermissionPaladin.Infrastructure.Enum;

namespace PermissionPaladin.Infrastructure.Caching;


public class CachingService : ICachingService
{
    private readonly IMemoryCache _cache;

    public CachingService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public TData? GetData<TData>(string key)
    {
        if (_cache.TryGetValue(key, out var data))
        {
            return (TData)data!;
        }

        return default;
    }

    public bool SetData<TData>(string key, TData data, CacheDuration duration)
    {
        if (KeyExists(key))
        {
            return false;
        }

        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(DateTime.UtcNow.AddSeconds((int)duration));

        _cache.Set(key, data, cacheOptions);
        return true;
    }

    private bool KeyExists(string key) => _cache.TryGetValue(key, out _);

}
