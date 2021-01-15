using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IActionResult> Index(string Search)
        {
            GetUser();
            
            
            if (Search == null)
            {
                var sp = _context.SanPhams.Where(u => u.TrangThai == 1).ToList();
                ViewBag.SP = sp;
                return View();

            }
            else if(int.Parse(Search) == 1)
            {
                SpcoKm();
                ViewBag.GiaTri = 1.ToString();
                return View();
            }
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

        public void SpcoKm()
        {
            var a = from sp in _context.SanPhams
                    where sp.TrangThai == 1 && sp.MaSP == (
                                         from spcokm in _context.SanPhams
                                         join km in _context.KhuyenMais on spcokm.MaSP equals km.MaKM
                                         where sp.MaSP == km.MaKM && spcokm.TrangThai == 1
                                         select spcokm.MaSP
                                      ).FirstOrDefault()
                    select sp;


            ViewBag.SP = a.ToList();
        }
    
    }
}
