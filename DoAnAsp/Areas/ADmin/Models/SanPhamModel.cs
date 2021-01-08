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

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name ="Tên sản phẩm")]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Giá")]
        [Range(0,1000000,ErrorMessage =("Giá phải lớn hơn 100 và nhỏ hơn 1000000"))]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Gia { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Số lượng")]
        public int Soluong { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Màn hình")]
        public string ManHinh { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name ="Hệ điều hành")]
        public string HDH { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Camera trước")]
        public string CameraTrc { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Camera sau")]
        public string CameraSau { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        public string CPU { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        public string ROM { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "PIN")]
        public string Pin { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Số sao")]
        public int SoSao { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }


        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

        public virtual KhuyenMaiModel KhuyenMai { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int MaLoaiSP { get; set; }
        [ForeignKey("MaLoaiSP")]
        public virtual LoaiSPModelcs LoaiSPs { get; set; }
        public ICollection<ChiTietHoaDonModel> chiTietHoaDon { get; set; }
        public ICollection<DanhGiaModel> danhGias { get; set; }

    }
}
