using F1Sharp;
using F1Sharp.Packets;

namespace BackEnd;

class F1TelemetryReader
{
    private TelemetryClient TelemetryClient { get; }
    
    private static uint OldTime { get; set; }

    private static bool TimeTrial { get; set; }
    
    /// <summary>
    /// Initiate the F1 telemetry reader.
    /// </summary>
    /// <param name="port">The port to listen to (default = 20777)</param>
    public F1TelemetryReader(int port = 20777)
    {
        TelemetryClient = new TelemetryClient(port);
        
        TelemetryClient.OnLapDataReceive += Client_OnLapDataRecieve;
        TelemetryClient.OnSessionDataReceive += Client_OnSessionDataRecieve;
    }

    public bool IsConnected()
    {
        return TelemetryClient.Connected;
    }
    
    private static void Client_OnLapDataRecieve(LapDataPacket packet)
    {
        // Get the player index from the list of cars in the session
        int playerIndex = packet.header.playerCarIndex;

        // Select the player's car from the list of car telemetries
        var carTelemetryData = packet.lapData[playerIndex];

        if (OldTime != carTelemetryData.lastLapTimeInMS)
        {
            OldTime = carTelemetryData.lastLapTimeInMS;
            
            var timeSpan = TimeSpan.FromMilliseconds(carTelemetryData.lastLapTimeInMS);

            var formattedTime = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}.{timeSpan.Milliseconds:D3}";

            Console.WriteLine($"Last laptime: {formattedTime}");
        }
    }

    private static void Client_OnSessionDataRecieve(SessionPacket packet)
    {
        if (!TimeTrial)
        {
            Console.WriteLine($"Time trial: {packet.sessionType == Session.TT}");
            TimeTrial = packet.sessionType == Session.TT;
        }
    }
}