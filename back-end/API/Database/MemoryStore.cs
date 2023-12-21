using API.Database.Interfaces;
using Core.Exceptions;
using Microsoft.Extensions.Caching.Memory;

namespace API.Database;

public class MemoryStore : IMemoryStore
{
    private readonly IMemoryCache _memoryCache;

    public MemoryStore(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    
    public string GetCachedData(string key)
    {
        if (!_memoryCache.TryGetValue(key, out string? cachedData))
        {
            if (cachedData == null) throw new MemoryCacheNotFoundException(key);
        }
        
        return cachedData!;
    }

    public void SetCachedData(string key, string value)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            // Set cache expiration and other options if needed
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1),
            // ...
        };
            
        _memoryCache.Set(key, value, cacheEntryOptions);
    }
}