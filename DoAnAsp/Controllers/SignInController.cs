﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DoAnAsp.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignInIndex()
        {
            return View();
        }
    }
}
