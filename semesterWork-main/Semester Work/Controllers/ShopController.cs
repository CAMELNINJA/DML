using Microsoft.AspNetCore.Mvc;
using Semester_Work.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL_carshop.Models;
using DAL_carshop.SeedData;

namespace Semester_Work.Controllers
{
    public class ShopController : Controller
    {
        private readonly List<Car> _cars;

        public ShopController()
        {
            SeedCar seed = new SeedCar();

            _cars = seed.DataCar();
            
                        
        }

        public IActionResult Index()
        {
            return View(_cars);
        }

        public IActionResult Product(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _cars.FirstOrDefault(m => m.Id == id);
            if (car== null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult Checkout()
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
