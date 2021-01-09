using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly DPContext _context;
        public ProductDetailController(DPContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ProductDetail(int? id)
        {
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
