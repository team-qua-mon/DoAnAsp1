using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Mvc;

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
            var sp = _context.SanPhams.Where(p=>p.TrangThai==1).ToList();
            var km = _context.KhuyenMais.Where(p => p.TrangThai == 1).ToList();

            var spSale = (from s in sp
                          join k in km on s.MaSP equals k.MaKM
                          select new
                          {
                              s.TenSP,
                              k.GiaTri,
                              s.HinhAnh,
                              s.Gia,
                              s.MaSP
                              
                          }).OrderByDescending(x => x.GiaTri).ToList();


            ViewBag.lispSPSale = spSale;

            ViewBag.ListLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            return View();
        }

        //public List<LoaiSPModelcs> ListLSP()
        //{
        //    return _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
        //}
        public IActionResult shop_grid()
        {
            var listLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            if(listLSP==null)
            { 
                return NotFound();
            }
            return View(listLSP);
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
            var listLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            if (listLSP == null)
            {
                return NotFound();
            }
            return View(listLSP);
        }
    }
}
