using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DoAnAsp.Areas.ADmin.Controllers
{
    public class HomeAdminController : Controller
    {
        private readonly DPContext _context;
        public HomeAdminController(DPContext context)
        {
            _context = context;
        }
        [Area("ADmin")]

        public IActionResult Index()
        {
            GetUser();
            return View();
        }
        public void GetUser()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
                NguoiDungModel ND = new NguoiDungModel();
                ND.UserName = us.SelectToken("UserName").ToString();
                ND.PassWord = us.SelectToken("PassWord").ToString();
                ViewBag.ND = _context.NguoiDungs.Where(nd => nd.UserName == ND.UserName).ToList();
            }


        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "HomeAdmin");
        }
    }
}
