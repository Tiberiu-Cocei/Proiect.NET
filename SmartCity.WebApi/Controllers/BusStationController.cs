using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartCity.WebApi.Controllers
{
    public class BusStationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}