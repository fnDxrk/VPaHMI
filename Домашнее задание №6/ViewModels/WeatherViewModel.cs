namespace Домашнее_задание__6.WeatherView
{
    public class WeatherViewModel
    {
        public WeatherViewModel(string? temperature, string? date, int weatherID)
        {
            Date = date;
            Temperature = temperature;
            WeatherID = weatherID;
        }

        public WeatherViewModel()
        {
        }

        public string? Date { get; set; }
        public string? Temperature { get; set; }
        public int WeatherID { get; set; }
    }
}