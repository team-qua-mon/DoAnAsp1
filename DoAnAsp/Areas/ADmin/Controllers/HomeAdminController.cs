using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DoAnAsp.Areas.ADmin.Controllers
{
    public class HomeAdminController : Controller
    {
        [Area("ADmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
