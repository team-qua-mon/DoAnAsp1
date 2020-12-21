using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace DoAnAsp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly DPContext _context;
        public LoginController(DPContext context)
        {
            _context = context;
        }
        public IActionResult loginIndex()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login([Bind("UserName,PassWord")] NguoiDungModel member)
        {
            //var y = StringProcessing.CreateMD5Hash("aa");
            var r = _context.NguoiDungs.Where(m => m.UserName == member.UserName && m.PassWord ==
             StringProcessing.CreateMD5Hash(member.PassWord)).ToList();
            if(r.Count==0)
            {
                var urlKcoTK = Url.RouteUrl(new { controller = "Login", action = "loginIndex" });
                return Redirect(urlKcoTK);
            }
            else if(r[0].MAQuyen == 1)
            {
                
                var urlUser = Url.RouteUrl(new { controller = "ShopBanDT", action = "Index" });
                return Redirect(urlUser);
            }
            else if(r[0].MAQuyen==2)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "HomeAdmin", action = "Index", area = "ADmin" });
                return Redirect(urlAdmin);
            }
            
            return RedirectToAction("Index", "ShopBanDT");
        }
    }
}

