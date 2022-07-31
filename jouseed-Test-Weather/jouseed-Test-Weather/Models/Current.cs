namespace jouseed_Test_Weather.Models
{
    public class Current
    {
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public double? feelslike_c { get; set; }
        public double? feelslike_f { get; set; }
        public double? humidity { get; set; }
        public double? windspeed { get; set; }

        public condition weathercondition { get; set; } = new condition();

    }
}
