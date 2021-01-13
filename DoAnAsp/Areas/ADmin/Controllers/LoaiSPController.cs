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
    public class LoaiSPController : Controller
    {
        private readonly DPContext _context;
        public void SetMessage(string Message, string type)
        {
            TempData["AlertMessage"] = Message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        public LoaiSPController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/LoaiSP
        public async Task<IActionResult> Index(string Search)
        {
            if(Search!=null)
            {
                var loaiSp = _context.LoaiSPs.Where(lsp => lsp.TenLSP.Contains(Search)).ToList();
                return View(loaiSp);
            }
            return View(await _context.LoaiSPs.Where(u=>u.TrangThai==1).ToListAsync());
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
        public async Task<IActionResult> AddAndEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new LoaiSPModelcs());
            }
            else
            {
                var loaiSP = await _context.LoaiSPs.FindAsync(id);
                if (loaiSP == null)
                {
                    return NotFound();
                }

                return View(loaiSP);
            }
        }

        // POST: ADmin/LoaiSP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAndEdit(int id,[Bind("MaLoaiSP,TenLSP,TrangThai")] LoaiSPModelcs loaiSPModelcs)
        {
            if (ModelState.IsValid)
            {
                if (id==0)
                {
                     _context.Update(loaiSPModelcs);
                    await _context.SaveChangesAsync();
                    SetMessage("Thêm loại sản phẩm thành công", "messages");
                }
                else
                {
                    try
                    {
                        _context.Update(loaiSPModelcs);
                        await _context.SaveChangesAsync();
                        SetMessage("Sửa loại sản phẩm thành công", "messages");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (LoaiSPModelcsExists(loaiSPModelcs.MaLoaiSP))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewLSP", _context.LoaiSPs.Where(u=>u.TrangThai==1).ToList()) });
            }
            ModelState.AddModelError("", "Thêm mới loại sản phẩm thất bại");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddAndEdit"), loaiSPModelcs });
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
        public async Task<IActionResult> Edit(int id, [Bind("MaLoaiSP,TenLSP,TrangThai")] LoaiSPModelcs loaiSPModelcs)
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
            loaiSPModelcs.TrangThai = 0;
            await _context.SaveChangesAsync();
            SetMessage("Xóa loại sản phẩm thành công", "messages");
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewLSP", _context.LoaiSPs.Where(u => u.TrangThai == 1).ToList()) });
        }

        private bool LoaiSPModelcsExists(int id)
        {
            return _context.LoaiSPs.Any(e => e.MaLoaiSP == id);
        }
    }
}
