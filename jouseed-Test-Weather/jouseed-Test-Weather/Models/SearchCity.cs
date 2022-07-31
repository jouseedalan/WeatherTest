using System.ComponentModel.DataAnnotations;

namespace jouseed_Test_Weather.Models
{
    public class SearchCity
    {
        // Annotations required to validate input data in our model.
        [Required(ErrorMessage = "You must enter a city name!")]
        //[RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only text allowed")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Enter a city name greater than 2 and lesser than 50 characters!")]
        [Display(Name = "City Name")]
        public string ?CityName { get; set; }
       
    }
}
