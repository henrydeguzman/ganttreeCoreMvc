﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ganttreeCoreMvc.Components
{
    public class Profilebar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
