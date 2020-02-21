using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganttreeCoreMvc.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ganttreeCoreMvc.Controllers
{
    public class Userprof : Controller
    {
        private readonly UserManager<StoreUser> _userManager;
        public Userprof(UserManager<StoreUser> userManager)
        {
            _userManager = userManager;
        }
        // GET: /<controller>/\ 
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var userid = _userManager.GetUserId(HttpContext.User);
            StoreUser user = _userManager.FindByIdAsync(userid).Result;
            ViewBag.title = "User Profile";
            ViewBag.pagetitle = "Personal Profile";
            ViewBag.themeBackground = "#ffde16";
            ViewBag.themeColor = "#444";

            return View(user);
        }
    }
}
