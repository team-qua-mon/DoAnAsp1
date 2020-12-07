using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;

namespace DoAnAsp.Areas.ADmin.Controllers
{
    [Area("ADmin")]
    public class SanPhamController : Controller
    {
        private readonly DPContext _context;

        public SanPhamController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/SanPham
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.SanPhams.Include(s => s.LoaiSPs);
            return View(await dPContext.ToListAsync());
        }

        // GET: ADmin/SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: ADmin/SanPham/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSPs, "MaLoaiSP", "MaLoaiSP");
            return View();
        }

        // POST: ADmin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,TenSP,Gia,Soluong,HinhAnh,ManHinh,HDH,CameraTrc,CameraSau,CPU,RAM,ROM,Pin,SoSao,MoTa,TrangThai,MaLoaiSP")] SanPhamModel sanPhamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPhamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSPs, "MaLoaiSP", "MaLoaiSP", sanPhamModel.MaLoaiSP);
            return View(sanPhamModel);
        }

        // GET: ADmin/SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhams.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSPs, "MaLoaiSP", "MaLoaiSP", sanPhamModel.MaLoaiSP);
            return View(sanPhamModel);
        }

        // POST: ADmin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSP,TenSP,Gia,Soluong,HinhAnh,ManHinh,HDH,CameraTrc,CameraSau,CPU,RAM,ROM,Pin,SoSao,MoTa,TrangThai,MaLoaiSP")] SanPhamModel sanPhamModel)
        {
            if (id != sanPhamModel.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamModelExists(sanPhamModel.MaSP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSPs, "MaLoaiSP", "MaLoaiSP", sanPhamModel.MaLoaiSP);
            return View(sanPhamModel);
        }

        // GET: ADmin/SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: ADmin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamModel = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPhamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPhams.Any(e => e.MaSP == id);
        }
    }
}
