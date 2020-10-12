using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serva40k.Models;

namespace Serva40k.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _dbContext = context;

        }
        
        [HttpGet("getZalypa")]
        public string GetZalypa(string name, string content, string category) 
        {
            _dbContext.Posts.Add(new TestDataModel{Name = name, Content = content, Category = category});
            _dbContext.SaveChanges();
            return "1";

        }

        

        public IActionResult Index()
        {
            _dbContext.Posts.Add(new TestDataModel{Name = "Zalypa", Content = "lypa", Category = "Buhgalteriya"});
            var a = _dbContext.Posts.Select(p => p.Name);

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
