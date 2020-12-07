using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class KhuyenMaiModel
    {   [Key]
        [ForeignKey("SanPham")]
        public int MaKM { get; set; }
        public string TenKM { get; set; }
        public string LoaiKM { get; set; }
        public int GiaTri { get; set; }
        public string NgayBD { get; set; }
        public string NgayKT { get; set; }
        public int TrangThai { get; set; }
        public virtual SanPhamModel SanPham { get; set; }
    }
}
