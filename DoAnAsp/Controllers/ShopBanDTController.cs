using System;
using System.Linq;
using System.Threading.Tasks;
using DoAnAsp.Areas.ADmin.Data;
using DoAnAsp.Areas.ADmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using DoAnAsp.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DoAnAsp.Controllers
{
    public class ShopBanDTController : Controller
    {
        private readonly DPContext _context;

        public ShopBanDTController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        
        {
            ViewBag.ListSPSamSung = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 2).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPOppo = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 3).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPXiaomi = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 4).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPVivvo = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 5).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPoneplus = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 8).OrderBy(sp => sp.MaSP).ToList();
            ViewBag.ListSPVimast = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 9).OrderBy(sp => sp.MaSP).ToList();
            //sp sắp hết
            ViewBag.ListSPsaphet = _context.SanPhams.Where(sp => sp.TrangThai == 1 && sp.MaLoaiSP == 9).OrderBy(x=>x.Soluong).Take(4).ToList();
            ViewBag.listsp = _context.SanPhams.Where(sp => sp.TrangThai == 1).ToList();
            //sao nhiều
            ViewBag.ListSaoNhieu = _context.SanPhams.Where(sp => sp.TrangThai == 1).OrderByDescending(sp => sp.SoSao).Take(4).ToList();

            //Đang giảm giá
            ViewBag.spkm = _context.KhuyenMais.Where(s => s.TrangThai == 1).Include(s => s.SanPham).OrderByDescending(s => s.GiaTri).Take(4).ToList();

            
            //loại sản phẩm
            ViewBag.ListLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            GetUser();
            DateTime d = DateTime.Now;

            return View();
        }

        
        public IActionResult shop_grid(int? page)
        {
            GetUser();
            var ListSP = _context.SanPhams.Where(sp => sp.TrangThai == 1).ToList();
            var listLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            var pageSize = 9;
            var PageNumber = page == null || page <=0 ? 1 : page.Value;
            if (listLSP==null)
            { 
                return NotFound();
            }
            ViewBag.SP = ListSP.ToPagedList(PageNumber, pageSize);
            return View(listLSP);
           
        }
        public IActionResult CheckOut()
        {
            GetUser();
            return View();
        }
        public IActionResult Cart()
        {
            GetUser();
            var cart = HttpContext.Session.GetString("CartSeeion");
            if (cart != null)
            {
                List<CartItem> dataCart = JsonConvert.DeserializeObject<List<CartItem>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.cart = dataCart;
                    return View();

                }
            }
            return View();
        }
        public SanPhamModel GetProduct(int id)
        {
            var product = _context.SanPhams.Find(id);
            return product;
        }


        public IActionResult AddCart(int id)
        {
            var cart = HttpContext.Session.GetString("CartSeeion");//get key cart
            if (cart == null)
            {
                var product = GetProduct(id);
                List<CartItem> listCart = new List<CartItem>()
                {
                    new CartItem
                    {
                        SanPham=product,
                        Quality=1
                    }
                };
                HttpContext.Session.SetString("CartSeeion", JsonConvert.SerializeObject(listCart));

            }
            else
            {
                List<CartItem> dataCart = JsonConvert.DeserializeObject<List<CartItem>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].SanPham.MaSP == id)
                    {
                        dataCart[i].Quality++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new CartItem
                    {
                        SanPham = GetProduct(id),
                        Quality = 1
                    });
                }
                HttpContext.Session.SetString("CartSeeion", JsonConvert.SerializeObject(dataCart));

                return RedirectToAction("Index", "ShopBanDT");

            }
            return RedirectToAction("Index", "ShopBanDT");

        }
        public IActionResult DeleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("CartSeeion");
            if (cart != null)
            {
                List<CartItem> dataCart = JsonConvert.DeserializeObject<List<CartItem>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].SanPham.MaSP == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                
                HttpContext.Session.SetString("CartSeeion", JsonConvert.SerializeObject(dataCart));
                HttpContext.Session.Remove("CartSeeion");
                return RedirectToAction(nameof(Cart));
            }
            return RedirectToAction(nameof(Cart));

        }
        public IActionResult Blog_Singe_Slidebar()
        {
            GetUser();
            
            var listLSP = _context.LoaiSPs.Where(lsp => lsp.TrangThai == 1).OrderBy(lsp => lsp.MaLoaiSP).ToList();
            if (listLSP == null)
            {
                return NotFound();
            }
            return View(listLSP);
        }
        public void GetUser()
        {
            if(HttpContext.Session.GetString("user") != null)
            {
                JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
                NguoiDungModel ND = new NguoiDungModel();
                ND.UserName = us.SelectToken("UserName").ToString();
                ND.PassWord = us.SelectToken("PassWord").ToString();
                ViewBag.ND = _context.NguoiDungs.Where(nd => nd.UserName == ND.UserName).ToList();
            }
           

        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "ShopBanDT");
        }
        
    }
}
