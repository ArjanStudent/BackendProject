using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservatie.Core.Data;
using Reservatie.Web.Models;

namespace Reservatie.Web.Controllers
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
            //dataInitializer.CreateData();
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
