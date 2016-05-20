using Microsoft.AspNet.Mvc;
using NgCooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCooking.APIControllers.Web
{
    class AppController : Controller
    {
        private NgCookingContext _context;

        public AppController(NgCookingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Communaute = _context.Communaute.ToList();
            return View();
        }
        public IActionResult tests()
        {
            var Communaute = _context.Communaute.ToList();
            return View();
        }
    }
}

