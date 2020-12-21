using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class DanhGiaModel
    {
        
         public int MaND { get; set; }
        public NguoiDungModel nguoiDung { get; set; }
        public int MaSP { get; set; }
        public SanPhamModel SanPham { get; set; }
        [Display(Name ="Bình luận")]
        public string Comment { get; set; }

        [Display(Name = "Số sao")]
        public int SoSao { get; set; }
    }
}
