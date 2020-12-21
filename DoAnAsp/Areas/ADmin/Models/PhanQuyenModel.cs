using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class PhanQuyenModel
    {
        [Key]
        public int MAQuyen { get; set; }

        [Display(Name ="Tên Quyền")]
        [Required]
        public string TenQuyen { get; set; }
        
        [Display(Name ="Mô tả")]
        [StringLength(maximumLength:200,ErrorMessage ="Không được quá 200 ký tự")]
        public string ChiTiet { get; set; }
        public ICollection<NguoiDungModel> nguoiDungs { get; set; }
    }
}
