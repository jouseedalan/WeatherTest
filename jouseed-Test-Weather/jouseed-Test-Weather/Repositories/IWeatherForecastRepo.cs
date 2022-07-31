using jouseed_Test_Weather.Models;
using jouseed_Test_Weather.ViewModels;

namespace jouseed_Test_Weather.Repositories
{
    public interface IWeatherForecastRepo
    {
      Task<WeatherResultViewModel> GetForecastAsync(string city);
    }
}
