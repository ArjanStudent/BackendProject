using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservatie.Core.Models;
using Reservatie.Models.Data;
using Reservatie.WebApp.Models;

namespace Reservatie.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataInitializer dataInitializer;
        public HomeController(IDataInitializer dataInitializer, ApplicationDbContext _context)
        {
            this.dataInitializer = dataInitializer;
            this._context = _context;
        }
        public IActionResult Index()
        {
            //var list = dataInitializer.Movies;
            //foreach(Movie m in list)
            //{
            //    _context.Movie.Add(m);
            //}
            //_context.SaveChanges();
            return View();
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
