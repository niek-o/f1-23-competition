namespace BackEnd;

class Program
{
    static void Main(string[] args)
    {
        // Instance the client listening on port 20777 (the default)
        var f1TelemetryReader = new F1TelemetryReader();
        
        Console.WriteLine(f1TelemetryReader.IsConnected());
        
        Console.CursorVisible = false;
        Console.Read();
    }
}
