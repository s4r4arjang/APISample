using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UseAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string Summary { get; set; }
        }
        public static class StaticItems
        {
            public static string EndPoint = "https://localhost:7140/api/";
        }

        public ActionResult  WeatherInfo()
            {
            var b = GetWeather();
            return View(b);
            }
        public List<WeatherForecast> GetWeather()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    
                    webClient.BaseAddress = StaticItems.EndPoint;
                    var json = webClient.DownloadString("WeatherForecast/Get");
                    var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
                    return list.ToList();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}