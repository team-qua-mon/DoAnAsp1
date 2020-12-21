using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class ChiTietHoaDonModel
    {
        public int MaSP { get; set; }
        public SanPhamModel sanPham { get; set; }
        public int MaHD { get; set; }
        public HoaDonModel hoaDon { get; set; }

        [Display(Name ="Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name ="Đơn giá")]
        public int DonGia { get; set; }

    }
}