using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackEnd_CH1.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;

namespace BackEnd_CH1.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
       
      
        private ILogger<HomeController> _logger;
        private LinkGenerator _linkGenerator;

        public HomeController(ILogger<HomeController> logger, LinkGenerator linkGenerator)
        {
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("")]
        [HttpGet("/")]
        [HttpGet("[action]")]

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("[action]", Name = "Car_List")]
        public IActionResult Link() {
            var link = _linkGenerator.GetPathByAction("Lamborghini Diablo!", "Home");
            var url = Url.RouteUrl("Car_List", new {}, Request.Scheme);
            return Content(url);
                }


        private static Users _Users = new Users
        {
            Username = "Rusty",
            Fullname = "Rusty Hermansen",
            Password = "Password",
            Car = "1967 Mustang",
            Food = "Sushi",
            Age = 33
        };
         [Route("Home/Contact")]
        public IActionResult Contact()
        {
            var json = JsonConvert.SerializeObject(_Users, Formatting.Indented);
            _logger.LogInformation(json);
            //throw new Exception("You should buy me lots of pizza, not cheap pizza either!");
            return View(_Users);
        }
        [HttpGet("[action]")]
        
        public IActionResult Privacy()
        {
            var json = JsonConvert.SerializeObject(_Users, Formatting.Indented);
            _logger.LogInformation(json);
            //throw new Exception("You should buy me lots of pizza, not cheap pizza either!");
            return View(_Users);
        }
        [HttpPost("[action]")]
        public IActionResult Privacy(Users users) 
        {
            if (ModelState.IsValid)
            {
                _Users.Fullname = users.Fullname;
                _Users.Username = users.Username;
                _Users.Password = users.Password;
                _Users.Car = users.Car;
                _Users.Food = users.Food;
                _Users.Age = users.Age;
                return RedirectToAction("Privacy");
            }
            else
            {
                return View(users);
            }
           
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
