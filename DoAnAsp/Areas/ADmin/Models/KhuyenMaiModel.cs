using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class KhuyenMaiModel
    {   
        [Key]
        [ForeignKey("SanPham")]
        public int MaKM { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [StringLength(maximumLength: 20, ErrorMessage = "không được dài quá 20 ký tự")]
        [Display(Name ="Tên khuyến mãi")]
        public string TenKM { get; set; }


        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Gái trị")]
        public int GiaTri { get; set; }


        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayBD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Ngày kết thúc")]
        public DateTime NgayKT { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public virtual SanPhamModel SanPham { get; set; }
    }
}
