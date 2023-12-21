namespace F1TelemetryReader;

class Program
{
    static void Main(string[] args)
    {
        // Instance the client listening on port 20777 (the default)
        var telemetryReader = new TelemetryReader();
        
        Console.WriteLine(telemetryReader.IsConnected());
        
        Console.CursorVisible = false;
        Console.Read();
    }
}