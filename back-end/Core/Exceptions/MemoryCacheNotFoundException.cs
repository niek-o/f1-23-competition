namespace Core.Exceptions;

public class MemoryCacheNotFoundException : Exception
{
    public MemoryCacheNotFoundException(string key)
    {
        throw new Exception($"Item '{key}' not found");
    }
}
