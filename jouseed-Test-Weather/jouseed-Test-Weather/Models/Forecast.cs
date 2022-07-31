namespace jouseed_Test_Weather.Models
{
    public class Forecast
    {
        public Forecast()
        {
            ForeCondition = new Lazy<condition>().Value;
        }    
        
        public string forecastday { get; set; }
        public string maxtemp { get; set; } 
        public string mintemp { get; set; } 
        public string avgHumidity { get; set; }
        public string maxwind_mph { get; set; }
        public condition ForeCondition { get; set; } 

    }
}
