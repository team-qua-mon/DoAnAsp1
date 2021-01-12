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
    public class SanPhamController : Controller
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
        public SanPhamController(DPContext context)
        {
            _context = context;
        }

        // GET: ADmin/SanPham
        public async Task<IActionResult> Index(string Search)
        {
            if (Search!=null)
            {
                ViewBag.ListLSP = _context.LoaiSPs.ToList();
                var sanpham = _context.SanPhams.Where(sp => sp.TenSP.Contains(Search)).ToList();
                return View("Index",sanpham);

            }
            var dPContext = _context.SanPhams.Where(u=>u.TrangThai==1).Include(s => s.LoaiSPs);
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
 
        public async Task<IActionResult> AddAndEdit(int id = 0)
        {
            if(id == 0)
            {
                ViewBag.ListLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).ToList();
                return View(new SanPhamModel()); 
            }
            else
            {
                var sanphamModel = await _context.SanPhams.FindAsync(id);
                if(sanphamModel == null)
                {
                    return NotFound();
                }
                ViewBag.ListLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).ToList();
                ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "TenSP", sanphamModel.MaSP);
                return View(sanphamModel);
            }
            
        }

        // POST: ADmin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAndEdit(int id,[Bind("MaSP,TenSP,Gia,Soluong,HinhAnh,ManHinh,HDH,CameraTrc,CameraSau,CPU,RAM,ROM,Pin,SoSao,MoTa,TrangThai,MaLoaiSP")] SanPhamModel sanPhamModel,IFormFile ful)
         {
            if (ModelState.IsValid)
            {
                if(id == 0)
                {
                    //_context.Add(sanPhamModel);
                    //await _context.SaveChangesAsync();
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Admin/ImgPro",
                        sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    sanPhamModel.HinhAnh = sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1];
            
                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                    SetMessage("Thêm sản phẩm thành công", "messages");
                }
                else
                {
                    try
                    {
                        
                        await _context.SaveChangesAsync();
                        if (ful!=null)
                        {
                            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Admin/ImgPro",
                        sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1]);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await ful.CopyToAsync(stream);
                            }
                            sanPhamModel.HinhAnh = sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                                [ful.FileName.Split(".").Length - 1];
                        }
                        _context.Update(sanPhamModel);
                        await _context.SaveChangesAsync();
                        SetMessage("Sửa sản phẩm thành công", "messages");
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
                }
                
                ViewBag.ListLSP = _context.LoaiSPs.Where(lsp=>lsp.TrangThai==1).ToList();
              
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewSanPham", _context.SanPhams.Where(u=>u.TrangThai==1).ToList()) });
            }
            ModelState.AddModelError("", "Thêm mới sản phẩm thất bại");
            ViewBag.ListLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).ToList();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddAndEdit", sanPhamModel) });
        }
        
        // GET: ADmin/SanPham/Edit/5
       
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
            ViewBag.ListLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).ToList();
            var sanPhamModel = await _context.SanPhams.FindAsync(id);
            sanPhamModel.TrangThai = 0;
            _context.Update(sanPhamModel);
            await _context.SaveChangesAsync();
            SetMessage("Xóa sản phẩm thành công", "messages");
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewSanPham", _context.SanPhams.Where(u=>u.TrangThai==1).ToList()) });
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPhams.Any(e => e.MaSP == id);
        }
    }
}
