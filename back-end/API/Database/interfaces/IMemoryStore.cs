using Microsoft.Extensions.Caching.Memory;

namespace API.Database.Interfaces;

public interface IMemoryStore
{
    void SetCachedData(string key, string value);
    string GetCachedData(string key);
}