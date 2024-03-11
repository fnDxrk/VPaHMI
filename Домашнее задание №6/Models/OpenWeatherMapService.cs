using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Домашнее_задание__6.Class;
internal class OpenWeatherMapService
{
    private readonly string _apiKey;
    private readonly HttpClient _client;

    public OpenWeatherMapService(string apiKey)
    {
        _apiKey = apiKey;
        _client = new HttpClient
        {
            BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/")
        };
    }


    public async Task<WeatherApiResponse> GetWeatherInformation(string city)
    {
        return await _client.GetFromJsonAsync<WeatherApiResponse>($"forecast?q={city}&units=metric&appid={_apiKey}");
        //forecast?q=Novosibirsk&appid=14fc70d81cb3cd2af2d6ece645c919ea
    }

}
