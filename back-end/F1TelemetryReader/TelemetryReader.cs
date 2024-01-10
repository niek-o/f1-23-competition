using System.Net.Http;
using System.Text;
using System.Text.Json;
using F1Sharp;
using F1Sharp.Packets;
using Core.Entities;
using Core.Entities.Dto;

namespace F1TelemetryReader;

public class TelemetryReader
{
    private readonly TelemetryClient _telemetryClient;

    private static uint OldTime { get; set; }

    private static SessionPacket SessionData { get; set; }

    private bool SessionStarted { get; set; } = false;

    private static bool ValidLap { get; set; }

    /// <summary>
    /// Initiate the F1 telemetry reader.
    /// </summary>
    /// <param name="port">The port to listen to (default = 20777)</param>
    public TelemetryReader(int port = 20777)
    {
        _telemetryClient = new TelemetryClient(port);

        _telemetryClient.OnLapDataReceive += Client_OnLapDataReceive;

        _telemetryClient.OnSessionDataReceive += Client_OnSessionDataReceive;
    }

    public bool IsConnected()
    {
        return _telemetryClient.Connected;
    }

    private static async void Client_OnLapDataReceive(LapDataPacket packet)
    {
        // Get the player index from the list of cars in the session
        int playerIndex = packet.header.playerCarIndex;

        // Select the player's car from the list of car telemetries
        var carTelemetryData = packet.lapData[playerIndex];

        if (OldTime != carTelemetryData.lastLapTimeInMS && !Convert.ToBoolean(carTelemetryData.currentLapInvalid))
        {
            ValidLap = true;

            OldTime = carTelemetryData.lastLapTimeInMS;

            var timeSpan = TimeSpan.FromMilliseconds(carTelemetryData.lastLapTimeInMS);

            var formattedTime = $"{timeSpan.Minutes:D1}:{timeSpan.Seconds:D2}.{timeSpan.Milliseconds:D3}";

            Console.WriteLine($"Last laptime: {formattedTime}");

            var laptime = new CreateLapDto
            {
                LapTimeInMS = Convert.ToInt32(carTelemetryData.lastLapTimeInMS),
                TrackId = SessionData.trackId
            };

            // TODO: POST Request Laptime to api/lap
            ApiClient apiClient = new ApiClient();

            await apiClient.PostRequest(laptime);
        }
    }

    private void Client_OnSessionDataReceive(SessionPacket packet)
    {
        if (packet.sessionType != Session.TT || SessionStarted) return;

        SessionStarted = true;
        Console.WriteLine($"Time trial: {packet.sessionType == Session.TT}");
        SessionData = packet;
    }
}