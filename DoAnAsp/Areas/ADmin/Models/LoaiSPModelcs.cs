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
        public string TenLSP { get; set; }
        public string Img { get; set; }
        public string Mota { get; set; }
        public ICollection<SanPhamModel> SanPhams { get; set; }
    }
}
