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
    public class HoaDonModelsController : Controller
    {
        private readonly DPContext _context;

        public HoaDonModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/HoaDonModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.HoaDons.ToListAsync());
        }

        // GET: ADmin/HoaDonModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDons
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // GET: ADmin/HoaDonModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADmin/HoaDonModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHD,NgayLap,NguoiNhan,SDTNgNhan,Andress,PhuongThucThanhToan,TongTien,TrangThai")] HoaDonModel hoaDonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoaDonModel);
        }

        // GET: ADmin/HoaDonModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDons.FindAsync(id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }
            return View(hoaDonModel);
        }

        // POST: ADmin/HoaDonModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHD,NgayLap,NguoiNhan,SDTNgNhan,Andress,PhuongThucThanhToan,TongTien,TrangThai")] HoaDonModel hoaDonModel)
        {
            if (id != hoaDonModel.MaHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonModelExists(hoaDonModel.MaHD))
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
            return View(hoaDonModel);
        }

        // GET: ADmin/HoaDonModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDons
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // POST: ADmin/HoaDonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDonModel = await _context.HoaDons.FindAsync(id);
            _context.HoaDons.Remove(hoaDonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonModelExists(int id)
        {
            return _context.HoaDons.Any(e => e.MaHD == id);
        }
    }
}
