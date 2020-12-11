using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DoAnAsp.Areas.ADmin.Controllers
{
    [Area("ADmin")]
    public class LoaiSPController : Controller
    {
        private readonly DPContext _context;

        public LoaiSPController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/LoaiSP
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSPs.ToListAsync());
        }

        // GET: ADmin/LoaiSP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSPModelcs = await _context.LoaiSPs
                .FirstOrDefaultAsync(m => m.MaLoaiSP == id);
            if (loaiSPModelcs == null)
            {
                return NotFound();
            }

            return View(loaiSPModelcs);
        }

        // GET: ADmin/LoaiSP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADmin/LoaiSP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoaiSP,TenLSP,Img,Mota")] LoaiSPModelcs loaiSPModelcs, IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSPModelcs);
                await _context.SaveChangesAsync();
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/Admin/ImgLSP",
                    loaiSPModelcs.MaLoaiSP + "." + ful.FileName.Split(".")
                    [ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                loaiSPModelcs.Img = loaiSPModelcs.MaLoaiSP + "." + ful.FileName.Split(".")
                    [ful.FileName.Split(".").Length - 1];
                _context.Update(loaiSPModelcs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSPModelcs);
        }

        // GET: ADmin/LoaiSP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSPModelcs = await _context.LoaiSPs.FindAsync(id);
            if (loaiSPModelcs == null)
            {
                return NotFound();
            }
            return View(loaiSPModelcs);
        }

        // POST: ADmin/LoaiSP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoaiSP,TenLSP,Img,Mota")] LoaiSPModelcs loaiSPModelcs)
        {
            if (id != loaiSPModelcs.MaLoaiSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSPModelcs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSPModelcsExists(loaiSPModelcs.MaLoaiSP))
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
            return View(loaiSPModelcs);
        }

        // GET: ADmin/LoaiSP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSPModelcs = await _context.LoaiSPs
                .FirstOrDefaultAsync(m => m.MaLoaiSP == id);
            if (loaiSPModelcs == null)
            {
                return NotFound();
            }

            return View(loaiSPModelcs);
        }

        // POST: ADmin/LoaiSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSPModelcs = await _context.LoaiSPs.FindAsync(id);
            _context.LoaiSPs.Remove(loaiSPModelcs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSPModelcsExists(int id)
        {
            return _context.LoaiSPs.Any(e => e.MaLoaiSP == id);
        }
    }
}
