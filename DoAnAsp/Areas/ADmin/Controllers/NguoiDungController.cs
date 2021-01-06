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
    public class NguoiDungController : Controller
    {
        private readonly DPContext _context;

        public NguoiDungController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/NguoiDung
        public async Task<IActionResult> Index(string Search)
        {
            if (Search != null)
            {
                ViewBag.ListPQ = _context.PhanQuyens.ToList();
                var nguoidung = _context.NguoiDungs.Where(sp =>( sp.TenND.Contains(Search) || sp.TenLot.Contains(Search) || sp.Ho.Contains(Search)) ).ToList();
                return View(nguoidung);

            }
            var dPContext = _context.NguoiDungs.Where(u => u.TrangThai == 1).Include(s => s.PhanQuyens);
            return View(await dPContext.ToListAsync());
        }

        // GET: ADmin/NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs
                .Include(n => n.PhanQuyens)
                .FirstOrDefaultAsync(m => m.MaND == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // GET: ADmin/NguoiDung/Create
        public async Task<IActionResult> AddAndEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ListPQ = _context.PhanQuyens.ToList();
                return View(new NguoiDungModel());
            }
            else
            {
                var nguoidungModel = await _context.NguoiDungs.FindAsync(id);
                if (nguoidungModel == null)
                {
                    return NotFound();
                }
                ViewBag.ListPQ = _context.PhanQuyens.ToList();
                ViewData["MaND"] = new SelectList(_context.NguoiDungs, "MaND", "TenND", nguoidungModel.MaND);
                return View(nguoidungModel);
            }
        }

        // POST: ADmin/NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAndEdit(int id,[Bind("MaND,Ho,TenLot,TenND,GioiTinh,HinhAnh,SDT,Andress,UserName,PassWord,TrangThai,MAQuyen")] NguoiDungModel nguoiDungModel, IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(nguoiDungModel);
                    await _context.SaveChangesAsync();
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Admin/ImgNgDung",
                        nguoiDungModel.MaND + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    nguoiDungModel.HinhAnh = nguoiDungModel.MaND + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1];
                    _context.Update(nguoiDungModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {

                        await _context.SaveChangesAsync();
                        if (ful != null)
                        {
                            var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/Admin/ImgNgDung",
                            nguoiDungModel.MaND + "." + ful.FileName.Split(".")
                            [ful.FileName.Split(".").Length - 1]);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await ful.CopyToAsync(stream);
                            }
                            nguoiDungModel.HinhAnh = nguoiDungModel.MaND + "." + ful.FileName.Split(".")
                                [ful.FileName.Split(".").Length - 1];
                        }
                        _context.Update(nguoiDungModel);
                        await _context.SaveChangesAsync();
                        
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!NguoiDungModelExists(nguoiDungModel.MaND))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                ViewBag.ListPQ = _context.PhanQuyens.ToList();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewNguoiDung", _context.NguoiDungs.Where(u => u.TrangThai == 1).ToList()) });
            }
            ViewBag.ListPQ = _context.PhanQuyens.ToList();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddAndEdit", nguoiDungModel) });
        }

        // GET: ADmin/NguoiDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }
            ViewData["MAQuyen"] = new SelectList(_context.PhanQuyens, "MAQuyen", "TenQuyen", nguoiDungModel.MAQuyen);
            return View(nguoiDungModel);
        }

        // POST: ADmin/NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaND,Ho,TenLot,TenND,GioiTinh,HinhAnh,SDT,Andress,UserName,PassWord,TrangThai,MAQuyen")] NguoiDungModel nguoiDungModel)
        {
            if (id != nguoiDungModel.MaND)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDungModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungModelExists(nguoiDungModel.MaND))
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
            ViewData["MAQuyen"] = new SelectList(_context.PhanQuyens, "MAQuyen", "TenQuyen", nguoiDungModel.MAQuyen);
            return View(nguoiDungModel);
        }

        // GET: ADmin/NguoiDung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs
                .Include(n => n.PhanQuyens)
                .FirstOrDefaultAsync(m => m.MaND == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // POST: ADmin/NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            _context.NguoiDungs.Remove(nguoiDungModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDungs.Any(e => e.MaND == id);
        }
    }
}
