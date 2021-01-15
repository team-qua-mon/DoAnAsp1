using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;

namespace DoAnAsp.Controllers
{
    public class LoginController : Controller
    {
        
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
        public async Task<IActionResult> loginIndex([Bind("UserName,PassWord")] NguoiDungModel member)
        {
            if(member.UserName != null && member.PassWord != null)
            {
                var r = _context.NguoiDungs.Where(m => m.UserName == member.UserName && m.PassWord ==
             (member.PassWord)).ToList();
                if (r.Count == 0 || r[0].MAQuyen == 1)
                {
                    SetMessage("Sai tài khoản hoặc mật khẩu", "Message");
                    return View("loginIndex");
                }
                else
                {

                    if (r[0].MAQuyen == 2)
                    {
                        var str = JsonConvert.SerializeObject(member);
                        HttpContext.Session.SetString("user", str);

                        var urlAdmin = Url.RouteUrl(new { controller = "ShopBanDT", action = "Index"});
                        return Redirect(urlAdmin);
                    }


                }
            }
            

            return View();
        }

        public void SetMessage(string Message, string type)
        {
            TempData["AlertMessage"] = Message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

    }
}

