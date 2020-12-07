using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DoAnAsp.Controllers
{
    public class ShopBanDTController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult shop_grid()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Blog_Singe_Slidebar()
        {
            return View();
        }
    }
}
