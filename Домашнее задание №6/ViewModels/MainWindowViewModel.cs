using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using Домашнее_задание__6.Class;
using Домашнее_задание__6.WeatherView;
using Домашнее_задание__6.WeatherWeekView;

namespace Домашнее_задание__6.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {   
            SelectedTheme();
            CurrentCity = "Novosibirsk";
            _OpenWeatherMapService = new OpenWeatherMapService("14fc70d81cb3cd2af2d6ece645c919ea");
            FetchWeatherInformation();
        }

        private readonly OpenWeatherMapService _OpenWeatherMapService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Date { get; set; } = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.Day.ToString();

        private string _temp { get; set; }
        public string CurrentTemperature
        {
            get { return _temp; }
            set
            {
                _temp = value;
                OnPropertyChanged(nameof(CurrentTemperature));
            }
        }
        private string _name { get; set; }
        public string? CurrentCity
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(CurrentCity));
                FetchWeatherInformation();
            }
        }

        public ObservableCollection<WeatherViewModel> WeatherList { get; set; } = [];

        public ObservableCollection<WeatherWeekViewModel> WeekWeatherList { get; set; } = [];

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
                CurrentTemperature = WeatherList[0].Temperature;
                WeekWeatherList.Clear();
                SetWeeklyWeather();
            }
        }

        private void SetWeeklyWeather()
        {
            for (int i = 0; i < 40; i++)
            {
                if (WeatherList[i].Date == "4:00")
                {
                    NightTemperature(i); break;
                }
                if (WeatherList[i].Date == "16:00")
                {
                    DayTemperature(i); break;
                }
            }
        }

        private void NightTemperature(int i)
        {
            WeatherWeekViewModel tempWeather;
            DateTime date = DateTime.Now;

            for (; i < 40; i++)
            {
                tempWeather = new WeatherWeekViewModel();
                tempWeather.TemperatureNight = WeatherList[i].Temperature;
                tempWeather.Date = WeatherList[i].Date;
                while (WeatherList[i].Date != "16:00" && i < 40)
                {
                    i++;
                }
                tempWeather.TemperatureDay = WeatherList[i].Temperature;
                tempWeather.Date = date.DayOfWeek.ToString() + ", " + date.Day.ToString();

                date = date.AddDays(1);
                WeekWeatherList.Add(tempWeather);
            }
        }

        private void DayTemperature(int i)
        {
            WeatherWeekViewModel tempWeather;
            DateTime date = DateTime.Now.AddDays(1);

            for (; i < 40; i++)
            {
                tempWeather = new WeatherWeekViewModel();
                tempWeather.TemperatureDay = WeatherList[i].Temperature;
                tempWeather.Date = WeatherList[i].Date;
                while (WeatherList[i].Date != "4:00" && i < 40)
                {
                    i++;
                }
                tempWeather.TemperatureNight = WeatherList[i].Temperature;
                tempWeather.Date = date.DayOfWeek.ToString() + ", " + date.Day.ToString();

                date = date.AddDays(1);

                WeekWeatherList.Add(tempWeather);
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
