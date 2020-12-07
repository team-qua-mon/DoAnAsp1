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
    public class ChiTietHoaDonController : Controller
    {
        private readonly DPContext _context;

        public ChiTietHoaDonController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/ChiTietHoaDon
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.ChiTietHoaDons.Include(c => c.hoaDon).Include(c => c.sanPham);
            return View(await dPContext.ToListAsync());
        }

        // GET: ADmin/ChiTietHoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.ChiTietHoaDons
                .Include(c => c.hoaDon)
                .Include(c => c.sanPham)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDonModel);
        }

        // GET: ADmin/ChiTietHoaDon/Create
        public IActionResult Create()
        {
            ViewData["MaHD"] = new SelectList(_context.HoaDons, "MaHD", "MaHD");
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "MaSP");
            return View();
        }

        // POST: ADmin/ChiTietHoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,MaHD,SoLuong,DonGia")] ChiTietHoaDonModel chiTietHoaDonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHoaDonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHD"] = new SelectList(_context.HoaDons, "MaHD", "MaHD", chiTietHoaDonModel.MaHD);
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "MaSP", chiTietHoaDonModel.MaSP);
            return View(chiTietHoaDonModel);
        }

        // GET: ADmin/ChiTietHoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.ChiTietHoaDons.FindAsync(id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }
            ViewData["MaHD"] = new SelectList(_context.HoaDons, "MaHD", "MaHD", chiTietHoaDonModel.MaHD);
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "MaSP", chiTietHoaDonModel.MaSP);
            return View(chiTietHoaDonModel);
        }

        // POST: ADmin/ChiTietHoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSP,MaHD,SoLuong,DonGia")] ChiTietHoaDonModel chiTietHoaDonModel)
        {
            if (id != chiTietHoaDonModel.MaHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHoaDonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHoaDonModelExists(chiTietHoaDonModel.MaHD))
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
            ViewData["MaHD"] = new SelectList(_context.HoaDons, "MaHD", "MaHD", chiTietHoaDonModel.MaHD);
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "MaSP", chiTietHoaDonModel.MaSP);
            return View(chiTietHoaDonModel);
        }

        // GET: ADmin/ChiTietHoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.ChiTietHoaDons
                .Include(c => c.hoaDon)
                .Include(c => c.sanPham)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDonModel);
        }

        // POST: ADmin/ChiTietHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHoaDonModel = await _context.ChiTietHoaDons.FindAsync(id);
            _context.ChiTietHoaDons.Remove(chiTietHoaDonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHoaDonModelExists(int id)
        {
            return _context.ChiTietHoaDons.Any(e => e.MaHD == id);
        }
    }
}
