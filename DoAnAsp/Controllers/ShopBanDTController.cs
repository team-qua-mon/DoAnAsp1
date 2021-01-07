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
            var sanpham = _context.SanPhams.Where(sp => sp.MaLoaiSP == 13).ToList();
            if(sanpham==null)
            {
                return NotFound();
            }
            return View(sanpham);
        }
       
        public async Task<IActionResult> shop_grid()
        {
            var listLSP = _context.LoaiSPs.ToList();
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
            return View();
        }
    }
}
