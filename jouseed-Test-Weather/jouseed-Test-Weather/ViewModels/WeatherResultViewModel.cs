using jouseed_Test_Weather.Models;

namespace jouseed_Test_Weather.ViewModels
{

    public class WeatherResultViewModel
    {
        //This View Model is used to show up result, this will be populated using various models Current - contains current wetaher details
        //Location  -contains location details of  input (city entered)
        //Fore cast - 7 Days Forecast details
        //Error Model - If the city is invalid, this model contains error details
        public WeatherResultViewModel()
        {
            location = new Lazy<Location>().Value;
            current = new Lazy<Current>().Value;
            forecasts = new Lazy<List<Forecast>>().Value;
            ErrorModel = new Lazy<ErrorModel>().Value;
        }

        public Location location { get; set; } //= new Location();
        public Current current { get; set; } //=new Current();
        public List<Forecast> forecasts { get; set; }//=new List<Forecast>();
        public ErrorModel? ErrorModel { get; set; }//=new ErrorModel();

    }






}
