using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_CH1.Controllers
{
    public class CarController : Controller
    {
        [Route("Car/{id:int}")]
        public IActionResult Story(int id)
        {
            return Content(id.ToString());
        }
    }
}
