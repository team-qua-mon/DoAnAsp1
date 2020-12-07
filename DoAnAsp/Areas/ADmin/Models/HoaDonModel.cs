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
        public string NgayLap { get; set; }
        public string NguoiNhan { get; set; }
        public string SDTNgNhan { get; set; }
        public string Andress { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public int TongTien { get; set; }
        public int TrangThai { get; set; }
        public virtual ChiTietHoaDonModel ChiTietHoaDons { get; set; }
        public ICollection<ChiTietHoaDonModel> chiTietHoaDon { get; set; }
    }
}
