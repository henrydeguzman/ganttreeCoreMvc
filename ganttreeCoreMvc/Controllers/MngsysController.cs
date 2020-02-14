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
            return View();
        }
    }
}