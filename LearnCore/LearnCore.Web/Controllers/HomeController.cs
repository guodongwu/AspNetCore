using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearnCore.Web.Models;
using Microsoft.AspNetCore.Http;
using LearnCore.Untity;

namespace LearnCore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CacheUntity.SetCache("test1", "Redis works");
            string redis = CacheUntity.GetCache<string>("test1");
            ViewBag.Redis = redis;

            CacheUntity.Init(new MemoryCacheHelper());
            CacheUntity.SetCache("test2", "MemoryCache works!");
            string memory= CacheUntity.GetCache<string>("test2");
            ViewBag.Memory = memory;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
             return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
