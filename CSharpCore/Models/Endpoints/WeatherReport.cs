namespace CSharpCore.Models.Endpoints
{
    public class WeatherReport
    {
        private static string[] _conditions = new string[] { "晴", "多云", "小雨" };
        private static Random _random = new();

        public string City { get; set; }
        public Dictionary<DateTime, WeatherInfo> WeatherInfos { get; set; }

        public WeatherReport(string city, int days)
        {
            City = city;
            WeatherInfos = [];
            for (int i = 0; i < days; i++)
            {
                this.WeatherInfos[DateTime.Now.AddDays(i)] = new WeatherInfo
                {
                    Condition = _conditions[_random.Next(0, 2)],
                    HighTemperature = _random.Next(20, 30),
                    LowTemperature = _random.Next(10, 20),
                };
            }
        }

        public WeatherReport(string city, DateTime dateTime)
        {
            City = city;
            WeatherInfos = new()
            {
                [dateTime] = new WeatherInfo
                {
                    Condition = _conditions[_random.Next(0, 2)],
                    HighTemperature = _random.Next(20, 30),
                    LowTemperature = _random.Next(10, 20),
                }
            };
        }
    }
}
