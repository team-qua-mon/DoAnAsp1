using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class LoaiSPModelcs
    {
        [Key]
        public int MaLoaiSP { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "không được dài quá 20 ký tự")]
        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name ="Tên loại sản phẩm")]
        public string TenLSP { get; set; }

        [Display(Name = "Trạng Thái")]
        public int TrangThai { get; set; }

        public ICollection<SanPhamModel> SanPhams { get; set; }
    }
}
