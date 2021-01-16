using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace DoAnAsp.Areas.ADmin.Controllers
{
    [Area("ADmin")]
    public class KhuyenMaiController : Controller
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
        public KhuyenMaiController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/KhuyenMai
        public async Task<IActionResult> Index(string Search)
        {
            GetUser();
            if (Search!=null)
            {
                ViewBag.ListSP = _context.SanPhams.Where(u => u.TrangThai == 1).ToList();
                var khuyenmai = _context.KhuyenMais.Where(km => km.TenKM.Contains(Search)).ToList();
                return View(khuyenmai);
            }
            var dPContext = _context.KhuyenMais.Where(u=>u.TrangThai==1).Include(k => k.SanPham);
            return View(await dPContext.ToListAsync());
        }

        // GET: ADmin/KhuyenMai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            GetUser();
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
                    SetMessage("Thêm khuyến mãi thành công", "messages");
                }
                else
                {
                    try
                    {
                        _context.Update(khuyenMaiModel);
                        await _context.SaveChangesAsync();
                        SetMessage("Sửa khuyến mãi thành công", "messages");
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
            ModelState.AddModelError("", "Thêm mới khuyến mãi thất bại");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddAndEdit", khuyenMaiModel) });
        }
            
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
            SetMessage("Xóa khuyến mãi thành công", "messages");
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewKhuyenMai", _context.KhuyenMais.ToList()) });

        }

        private bool KhuyenMaiModelExists(int id)
        {
            return _context.KhuyenMais.Any(e => e.MaKM == id);
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
