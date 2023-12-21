namespace Core.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(Type type)
    {
        throw new Exception($"Resource {type} not found");
    }
}
