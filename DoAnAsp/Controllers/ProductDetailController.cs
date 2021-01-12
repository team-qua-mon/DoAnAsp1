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

namespace DoAnAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly DPContext _context;
        public ProductDetailController(DPContext context)
        {
            _context = context;
        }
        public void GetUser()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
            NguoiDungModel ND = new NguoiDungModel();
            ND.UserName = us.SelectToken("UserName").ToString();
            ND.PassWord = us.SelectToken("PassWord").ToString();
            ViewBag.ND = _context.NguoiDungs.Where(nd => nd.UserName == ND.UserName).ToList();

        }
        public async Task<IActionResult> ProductDetail(int? id)
        {
            GetUser();
                if (id == null)
                {
                    return NotFound();
                }

                var sanPhamModel = await _context.SanPhams
                    .Include(s => s.LoaiSPs)
                    .FirstOrDefaultAsync(m => m.MaSP == id);
                if (sanPhamModel == null)
                {
                    return NotFound();
                }

                return View(sanPhamModel);
        }
    }
}
