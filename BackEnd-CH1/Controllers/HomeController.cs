using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackEnd_CH1.Models;
using Newtonsoft.Json;

namespace BackEnd_CH1.Controllers
{
    public class HomeController : Controller
    {
      
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public String Contact()
        {
            var user = new Users
            {
                Username = "Rusty",
                Fullname = "Rusty Hermansen",
                Password = "Password",
                Car= "1967 Mustang",
                Food = "Sushi",
                Age = 33

            };
            var json = JsonConvert.SerializeObject(user, Formatting.Indented);
            _logger.LogInformation(json);
            //throw new Exception("You should buy me lots of pizza, not cheap pizza either!");
            return json;
        }
        public IActionResult Privacy()
        {
           return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
