using jouseed_Test_Weather.Models;
using jouseed_Test_Weather.Repositories;
using jouseed_Test_Weather.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace jouseed_Test_Weather.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastRepo _forecastRepo;

        public WeatherForecastController(IWeatherForecastRepo forecastRepo)
        {
            this._forecastRepo = forecastRepo;
        }
        [HttpGet]
        public IActionResult SearchCity()
        {
            if (ModelState.IsValid)
            {
                var viewModel = new SearchCity();
                return View(viewModel);
            }

           
            return View();


        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("WeatherForecastResult", "WeatherForecast", new { city = model.CityName });
            }

            

            return View();
        }


        public async Task<IActionResult> WeatherForecastResult(string city)
        {
            // Consume the OpenWeatherAPI in order to bring Forecast data in our page.
            WeatherResultViewModel weatherResponse = await _forecastRepo.GetForecastAsync(city);          

            if(weatherResponse.ErrorModel.code== 1006)
            {
                
                //ModelState.AddModelError(city, "Please Enter Valid City");
               ViewBag.ErrorMessageForCity = "Please Enter Valid City";
                return View("SearchCity");
                //return RedirectToAction("SearchCity", "WeatherForecast");
               // return BadRequest("SearchCity");
            }
            return View(weatherResponse);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
