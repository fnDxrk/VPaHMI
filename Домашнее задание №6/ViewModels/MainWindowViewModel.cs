using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Домашнее_задание__6.Class;
using Домашнее_задание__6.WeatherView;

namespace Домашнее_задание__6.ViewModels
{
    public class MainWindowViewModel
    {
        //14fc70d81cb3cd2af2d6ece645c919ea
        public MainWindowViewModel()
        {
            _OpenWeatherMapService = new OpenWeatherMapService("14fc70d81cb3cd2af2d6ece645c919ea");
            FetchWeatherInformation();
        }

        private readonly OpenWeatherMapService _OpenWeatherMapService;

        public string? CurrentCity = "Novosibirsk";

        public ObservableCollection<WeatherViewModel> WeatherList { get; set; } = [];

        public WeatherViewModel SelectedWeather { get; set; }

        private async Task FetchWeatherInformation()
        {
            var weatherApiResponse = await _OpenWeatherMapService.GetWeatherInformation(CurrentCity);
            if (weatherApiResponse != null)
            {
                WeatherList.Clear();
                for (int i = 0; i < 40; i++)
                {
                    WeatherList.Add(new WeatherViewModel($"{Math.Round(Convert.ToDouble(weatherApiResponse.List[i].main.temp))}°C", 
                    GetTime(weatherApiResponse.List[i].dt_txt), 
                    weatherApiResponse.List[i].weather[0].id));
                }
            }
        }

        private string GetTime(string date)
        {
            int tempTime = System.Convert.ToInt32(date.Substring(date.LastIndexOf(" ") + 1).Remove(2));
            if (tempTime <= 19)
            {
                tempTime += 4;
            }
            else
            {
                tempTime -= 20;
            }

            return tempTime.ToString() + ":00";
        }
    }
}
