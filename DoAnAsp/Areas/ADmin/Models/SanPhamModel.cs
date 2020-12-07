using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class SanPhamModel
    {
        [Key]
        public int MaSP { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [Display(Name ="Tên sản phẩm")]
        public string TenSP { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        [Display(Name = "Giá")]
        public int Gia { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Display(Name = "Số lượng")]
        public int Soluong { get; set; }
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Màn hình")]
        public string ManHinh { get; set; }
        public string HDH { get; set; }
        public string CameraTrc { get; set; }
        public string CameraSau { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string ROM { get; set; }
        public string Pin { get; set; }
        public int SoSao { get; set; }
        public string MoTa { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public virtual KhuyenMaiModel KhuyenMai { get; set; }
        public int MaLoaiSP { get; set; }
        [ForeignKey("MaLoaiSP")]
        public virtual LoaiSPModelcs LoaiSPs { get; set; }
        public ICollection<ChiTietHoaDonModel> chiTietHoaDon { get; set; }
        public ICollection<DanhGiaModel> danhGias { get; set; }

    }
}
