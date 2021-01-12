using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;


namespace DoAnAsp.Controllers
{
    public class ShopBanDTController : Controller
    {
        private readonly DPContext _context;

        public ShopBanDTController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ListSPSamSung = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 2).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPOppo = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 3).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPXiaomi = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 4).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPVivvo = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 5).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPoneplus = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 8).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPVimast = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 9).OrderBy(sp => sp.MaSP).ToList();

            //sao nhiều
            ViewBag.ListSaoNhieu = _context.SanPhams.Where(sp => sp.TrangThai == 1).OrderByDescending(sp => sp.SoSao).Take(4).ToList();

            //Đang giảm giá
            ViewBag.spkm = _context.SanPhams.Where(p => p.TrangThai == 1).Include(s => s.KhuyenMai).OrderByDescending(x=>x.KhuyenMai.GiaTri).Take(4).ToList();

            
            //loại sản phẩm
            ViewBag.ListLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            GetUser();
            DateTime d = DateTime.Now;

            //var spbannhieu= (from cthd in _context.ChiTietHoaDons
            //                join sp in _context.SanPhams on cthd.MaSP equals sp.MaSP
            //                join hd in _context.HoaDons on cthd.MaHD equals hd.MaHD
            //                where hd.NgayLap==(d.AddMonths(-1)) 
            //                select 
            //                )
            return View();
        }

        
        public IActionResult shop_grid()
        {
            GetUser();
            var listLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            if(listLSP==null)
            { 
                return NotFound();
            }
            return View(listLSP);
        }
        public IActionResult CheckOut()
        {
            GetUser();
            return View();
        }
        public IActionResult Cart()
        {
            GetUser();
            return View();
        }
        public IActionResult Blog_Singe_Slidebar()
        {
            GetUser();
            
            var listLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            if (listLSP == null)
            {
                return NotFound();
            }
            return View(listLSP);
        }
        public void GetUser()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
            NguoiDungModel ND = new NguoiDungModel();
            ND.UserName = us.SelectToken("UserName").ToString();
            ND.PassWord = us.SelectToken("PassWord").ToString();
            ViewBag.ND = _context.NguoiDungs.Where(nd => nd.UserName == ND.UserName).ToList();

        }
    }
}
