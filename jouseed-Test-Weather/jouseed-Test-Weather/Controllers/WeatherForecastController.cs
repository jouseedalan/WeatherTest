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
            var viewModel = new SearchCity();
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            // If the model is valid, pass it to WeatherForecastResult controller action
            if (ModelState.IsValid)
            {
                return RedirectToAction("WeatherForecastResult", "WeatherForecast", new { city = model.CityName });
            }

            //If any validation error, show up city view with error message
            return View();
        }


        public async Task<IActionResult> WeatherForecastResult(string city)
        {
            // Consume the Weather API in order to get weather forecast details and pass it to view.
            WeatherResultViewModel weatherResponse = await _forecastRepo.GetForecastAsync(city);
            //if the city is invalid, pass the error message to view and return city view itself
            if (weatherResponse.ErrorModel.code == 1006)
            {
                //ModelState.AddModelError(city, "Please Enter Valid City");
                ViewBag.ErrorMessageForCity = "Please Enter Valid City";
                return View("SearchCity");
                //return RedirectToAction("SearchCity", "WeatherForecast");
                // return BadRequest("SearchCity");
            }
            //Upon success wetaher reponse, pass the reponse to result view WeatherForecastResult
            return View(weatherResponse);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
