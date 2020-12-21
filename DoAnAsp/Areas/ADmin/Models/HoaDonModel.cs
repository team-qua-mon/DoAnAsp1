using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class HoaDonModel
    {
        [Key]
        public int MaHD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Ngày lập")]
        public DateTime NgayLap { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Người nhận")]
        public string NguoiNhan { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 20, ErrorMessage = "không được nhập quá 20 ký tự")]
        public string SDTNgNhan { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [StringLength(maximumLength: 300, ErrorMessage = "Địa Chỉ Dài Hơn 8 Ký Tự")]
        [Display(Name = "Địa Chỉ")]
        public string Andress { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [StringLength(maximumLength: 300, ErrorMessage = "Địa Chỉ Dài Hơn 8 Ký Tự")]
        [Display(Name = "Địa Chỉ")]
        public string PhuongThucThanhToan { get; set; }

        [Range(100, 1000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public virtual ChiTietHoaDonModel ChiTietHoaDons { get; set; }
        public ICollection<ChiTietHoaDonModel> chiTietHoaDon { get; set; }
    }
}
