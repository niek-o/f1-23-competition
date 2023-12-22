using System.Net.Http.Json;
using Core.Entities.Dto;

namespace F1TelemetryReader;

public class ApiClient
{
    private static HttpClient client;

    public ApiClient()
    {
        client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5058/")
        };
    }

    public async Task PostRequest(CreateLapDto lap)
    {
        var response = await client.PostAsJsonAsync(
            "lap", lap);
        var result = await response.Content.ReadAsStringAsync();

        Console.WriteLine(result);
    }
}