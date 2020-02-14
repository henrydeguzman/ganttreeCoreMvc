using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ganttreeCoreMvc.Controllers
{
    public class MngsysController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.title = "Management System";
            ViewBag.themeBackground = "#163318";
            ViewBag.themeColor = "white";
            return View();
        }
    }
}