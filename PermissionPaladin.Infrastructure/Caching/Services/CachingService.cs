using Microsoft.Extensions.Caching.Memory;
using PermissionPaladin.Infrastructure.Caching.Interfaces;
using PermissionPaladin.Infrastructure.Enum;

namespace PermissionPaladin.Infrastructure.Caching.Services;

/// <summary>
/// Service providing caching functionality using MemoryCache
/// </summary>
public class CachingService : ICachingService
{
    private readonly IMemoryCache _cache;

    /// <summary>
    /// Initializes a new instance of the CachingService class
    /// </summary>
    /// <param name="cache">The IMemoryCache implementation</param>
    public CachingService(IMemoryCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    /// Retrieves cached data by the specified key
    /// </summary>
    /// <typeparam name="TData">The type of the cached data</typeparam>
    /// <param name="key">The unique key associated with the cached data</param>
    /// <returns>The cached data if available; otherwise, the default value for the data type.</returns>
    public TData? GetData<TData>(string key)
    {
        if (_cache.TryGetValue(key, out var data))
        {
            return (TData)data!;
        }

        return default;
    }

    /// <summary>
    /// Sets cached data with the specified key and duration
    /// </summary>
    /// <typeparam name="TData">The type of the data to be cached</typeparam>
    /// <param name="key">The unique key associated with the cached data</param>
    /// <param name="data">The data to be cached</param>
    /// <param name="duration">The duration for which the data should be cached</param>
    /// <returns>True if the data was successfully cached; otherwise, false if the key already exists</returns>
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
