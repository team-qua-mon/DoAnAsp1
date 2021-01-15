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
    public class ThongKeController : Controller
    {
        private readonly DPContext _context;
        // GET: ThongKeController
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
        public async Task<IActionResult> Index(string Search)
        {
            GetUser();
            if (Search != null)
            {
                ViewBag.ListLSP = _context.LoaiSPs.ToList();
                var sanpham = _context.SanPhams.Where(sp => sp.TenSP.Contains(Search)).ToList();
                return View("Index", sanpham);

            }
            var dPContext = _context.SanPhams.Where(u => u.TrangThai == 1).Include(s => s.LoaiSPs);
            return View(await dPContext.ToListAsync());
        }

        // GET: ThongKeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThongKeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongKeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ThongKeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ThongKeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ThongKeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThongKeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
