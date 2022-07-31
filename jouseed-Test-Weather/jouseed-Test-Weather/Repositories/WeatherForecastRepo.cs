using jouseed_Test_Weather.Configs;
using jouseed_Test_Weather.Models;
using jouseed_Test_Weather.ViewModels;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace jouseed_Test_Weather.Repositories
{
    public class WeatherForecastRepo : IWeatherForecastRepo
    {
        public async Task<WeatherResultViewModel> GetForecastAsync(string city)
        {
            string API_key = WeatherapiConfigs.WEATHER_API_KEY;
            string API_URL = WeatherapiConfigs.WEATHER_API_URL;
            string url = string.Format($"{API_URL}?key={API_key}&q={city}&days=7&aqi=no&alerts=no");
            string result = "";
            WeatherResultViewModel weatherResponse =new WeatherResultViewModel();
            using (HttpClient client = new HttpClient())
             {
               var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                var statuscode = response.StatusCode;       
                
                //result = client.DownloadString(url);
                // result = await client.GetStringAsync(url);
                dynamic myJObject = JObject.Parse(result);


                if (myJObject!=null && response.StatusCode==HttpStatusCode.OK)
                {
                    
                    weatherResponse.location.name = myJObject.location.name;
                    weatherResponse.location.region = myJObject.location.region;
                    weatherResponse.location.country = myJObject.location.country;
                    weatherResponse.current.temp_c = myJObject.current.temp_c;
                    weatherResponse.current.temp_f = myJObject.current.temp_f;
                    weatherResponse.current.feelslike_c = myJObject.current.feelslike_c;
                    weatherResponse.current.feelslike_f = myJObject.current.feelslike_f;
                    weatherResponse.current.humidity = myJObject.current.humidity;
                    weatherResponse.current.windspeed=myJObject.current.wind_mph;
                   weatherResponse.current.weathercondition.text = myJObject.current.condition.text;
                    weatherResponse.current.weathercondition.icon = myJObject.current.condition.icon;

                    for (int i = 0; i <7; i++)
                    {
                        Forecast day = new Forecast();
                        day.forecastday = myJObject.forecast.forecastday[i].date;
                        day.maxtemp = myJObject.forecast.forecastday[i].day.maxtemp_c;
                        day.mintemp = myJObject.forecast.forecastday[i].day.mintemp_c;
                        day.avgHumidity = myJObject.forecast.forecastday[i].day.avghumidity;
                        day.maxwind_mph = myJObject.forecast.forecastday[i].day.maxwind_mph;
                        day.ForeCondition.text = myJObject.forecast.forecastday[i].day.condition.text;
                        day.ForeCondition.icon = myJObject.forecast.forecastday[i].day.condition.icon;

                        weatherResponse.forecasts.Add(day);

                    }
                    weatherResponse.ErrorModel.code = 0;
                    weatherResponse.ErrorModel.message = "";

                }

                else
                {
                    weatherResponse.ErrorModel.code = myJObject.error.code;
                    weatherResponse.ErrorModel.message = myJObject.error.message;
                }        
            }

            return weatherResponse;
        }

        
    }
}
