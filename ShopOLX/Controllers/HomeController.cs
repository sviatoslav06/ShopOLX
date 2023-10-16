using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using ShopOLX.Models;
using System.Diagnostics;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace ShopOLX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext ctx;

        public HomeController(ILogger<HomeController> logger, ShopDbContext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View(ctx.Products.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Show(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            ViewBag.Message = item;

            return View("ShowProduct");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}