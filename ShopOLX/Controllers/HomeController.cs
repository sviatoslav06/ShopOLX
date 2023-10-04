using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using ShopOLX.Models;
using System.Diagnostics;

namespace ShopOLX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext ctx;

        //public HomeController()
        //{
        //    this.ctx = ctx;
        //}

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}