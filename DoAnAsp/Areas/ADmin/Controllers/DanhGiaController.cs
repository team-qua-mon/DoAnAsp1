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
    public class DanhGiaController : Controller
    {
        private readonly DPContext _context;

        public DanhGiaController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/DanhGia
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.DanhGias.Include(d => d.SanPham).Include(d => d.nguoiDung);
            return View(await dPContext.ToListAsync());
        }

        // GET: ADmin/DanhGia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGiaModel = await _context.DanhGias
                .Include(d => d.SanPham)
                .Include(d => d.nguoiDung)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (danhGiaModel == null)
            {
                return NotFound();
            }

            return View(danhGiaModel);
        }

        // GET: ADmin/DanhGia/Create
        public IActionResult Create()
        {
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "CPU");
            ViewData["MaND"] = new SelectList(_context.NguoiDungs, "MaND", "Andress");
            return View();
        }

        // POST: ADmin/DanhGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaND,MaSP,Comment,SoSao")] DanhGiaModel danhGiaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhGiaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "CPU", danhGiaModel.MaSP);
            ViewData["MaND"] = new SelectList(_context.NguoiDungs, "MaND", "Andress", danhGiaModel.MaND);
            return View(danhGiaModel);
        }

        // GET: ADmin/DanhGia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGiaModel = await _context.DanhGias.FindAsync(id);
            if (danhGiaModel == null)
            {
                return NotFound();
            }
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "CPU", danhGiaModel.MaSP);
            ViewData["MaND"] = new SelectList(_context.NguoiDungs, "MaND", "Andress", danhGiaModel.MaND);
            return View(danhGiaModel);
        }

        // POST: ADmin/DanhGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaND,MaSP,Comment,SoSao")] DanhGiaModel danhGiaModel)
        {
            if (id != danhGiaModel.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhGiaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhGiaModelExists(danhGiaModel.MaSP))
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
            ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "CPU", danhGiaModel.MaSP);
            ViewData["MaND"] = new SelectList(_context.NguoiDungs, "MaND", "Andress", danhGiaModel.MaND);
            return View(danhGiaModel);
        }

        // GET: ADmin/DanhGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGiaModel = await _context.DanhGias
                .Include(d => d.SanPham)
                .Include(d => d.nguoiDung)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (danhGiaModel == null)
            {
                return NotFound();
            }

            return View(danhGiaModel);
        }

        // POST: ADmin/DanhGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhGiaModel = await _context.DanhGias.FindAsync(id);
            _context.DanhGias.Remove(danhGiaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaModelExists(int id)
        {
            return _context.DanhGias.Any(e => e.MaSP == id);
        }
    }
}
