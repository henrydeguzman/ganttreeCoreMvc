using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ganttreeCoreMvc.Controllers
{
    public class Publications : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "S.O.P. Publications";
            ViewBag.themeBackground = "#ffffff";
            return View();
        }
    }
}
