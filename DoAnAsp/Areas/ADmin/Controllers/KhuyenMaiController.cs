﻿using System;
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
    public class KhuyenMaiController : Controller
    {
        private readonly DPContext _context;

        public KhuyenMaiController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/KhuyenMai
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.KhuyenMais.Where(u=>u.TrangThai==1).Include(k => k.SanPham);
            return View(await dPContext.ToListAsync());
        }

        // GET: ADmin/KhuyenMai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMaiModel = await _context.KhuyenMais
                .Include(k => k.SanPham)
                .FirstOrDefaultAsync(m => m.MaKM == id);
            if (khuyenMaiModel == null)
            {
                return NotFound();
            }

            return View(khuyenMaiModel);
        }

        // GET: ADmin/KhuyenMai/Create
        public async Task<IActionResult> AddAndEdit(int id=0)
        {
            if(id==0)
            {
                ViewBag.ListSP = _context.SanPhams.Where(u => u.TrangThai == 1).ToList();
                return View(new KhuyenMaiModel());
            }
            else
            {
                var khuyenmaiModel = await _context.KhuyenMais.FindAsync(id);
                if(khuyenmaiModel==null)
                {
                    return NotFound();
                }
                ViewBag.ListSP = _context.SanPhams.Where(u=>u.TrangThai==1).ToList();
                ViewData["MaKM"] = new SelectList(_context.KhuyenMais, "MaKM", "Ten");
                return View(khuyenmaiModel);
            }
            
        }

        // POST: ADmin/KhuyenMai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAndEdit(int id,[Bind("MaKM,TenKM,GiaTri,NgayBD,NgayKT,TrangThai")] KhuyenMaiModel khuyenMaiModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(khuyenMaiModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(khuyenMaiModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if(KhuyenMaiModelExists(khuyenMaiModel.MaKM))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }   
                    }
                }
                ViewBag.ListSP = _context.SanPhams.Where(u => u.TrangThai == 1).ToList();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewKhuyenMai", _context.KhuyenMais.Where(u => u.TrangThai == 1).ToList()) });
            }
            ViewBag.ListSP = _context.SanPhams.Where(u => u.TrangThai == 1).ToList();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddAndEdit", khuyenMaiModel) });
        }
            
        // GET: ADmin/KhuyenMai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMaiModel = await _context.KhuyenMais.FindAsync(id);
            if (khuyenMaiModel == null)
            {
                return NotFound();
            }
            ViewData["MaKM"] = new SelectList(_context.SanPhams, "MaSP", "TenSP", khuyenMaiModel.MaKM);
            return View(khuyenMaiModel);
        }

        // POST: ADmin/KhuyenMai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKM,TenKM,GiaTri,NgayBD,NgayKT,TrangThai")] KhuyenMaiModel khuyenMaiModel)
        {
            if (id != khuyenMaiModel.MaKM)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khuyenMaiModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenMaiModelExists(khuyenMaiModel.MaKM))
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
            ViewData["MaKM"] = new SelectList(_context.SanPhams, "MaSP", "TenSP", khuyenMaiModel.MaKM);
            return View(khuyenMaiModel);
        }

        // GET: ADmin/KhuyenMai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMaiModel = await _context.KhuyenMais
                .Include(k => k.SanPham)
                .FirstOrDefaultAsync(m => m.MaKM == id);
            if (khuyenMaiModel == null)
            {
                return NotFound();
            }

            return View(khuyenMaiModel);
        }

        // POST: ADmin/KhuyenMai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.ListSP = _context.SanPhams.Where(u => u.TrangThai == 1).ToList();
            var khuyenMaiModel = await _context.KhuyenMais.FindAsync(id);
            _context.Remove(khuyenMaiModel);
            await _context.SaveChangesAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewKhuyenMai", _context.KhuyenMais.ToList()) });

        }

        private bool KhuyenMaiModelExists(int id)
        {
            return _context.KhuyenMais.Any(e => e.MaKM == id);
        }
    }
}
