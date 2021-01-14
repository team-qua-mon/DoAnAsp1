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
using Newtonsoft.Json.Linq;

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
        // GET: ADmin/NguoiDung
        public async Task<IActionResult> Index(string Search)
        {
            GetUser();
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
                    //_context.Add(nguoiDungModel);
                    //await _context.SaveChangesAsync();
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
                    SetMessage("Thêm người dùng thành công", "messages");
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
                        SetMessage("Sửa người dùng thành công", "messages");

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
            ModelState.AddModelError("", "Thêm mới người dùng thất bại");
            ViewBag.ListPQ = _context.PhanQuyens.ToList();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddAndEdit", nguoiDungModel) });
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
            ViewBag.ListPQ = _context.PhanQuyens.ToList();
            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            nguoiDungModel.TrangThai = 0;
            await _context.SaveChangesAsync();
            SetMessage("Xóa người dùng thành công", "messages");
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewNguoiDung", _context.NguoiDungs.Where(u => u.TrangThai == 1).ToList()) });

        }

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDungs.Any(e => e.MaND == id);
        }
        public void GetUser()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
                NguoiDungModel ND = new NguoiDungModel();
                ND.UserName = us.SelectToken("UserName").ToString();
                ND.PassWord = us.SelectToken("PassWord").ToString();
                ViewBag.ND = _context.NguoiDungs.Where(nd => nd.UserName == ND.UserName).ToList();
            }


        }
        
    }
}
