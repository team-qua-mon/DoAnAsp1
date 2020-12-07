using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Models
{
    public class NguoiDungModel
    {
        [Key]
        public int MaND { get; set; }

        [Display(Name ="Họ")]
        public string Ho { get; set; }
        [Display(Name = "Tên lót")]
        public string TenLot { get; set; }
        [Display(Name = "Tên  người dùng")]
        public string TenND { get; set; }
        public string GioiTinh { get; set; }
        public string HinhAnh { get; set; }
        public string SDT { get; set; }
        public string Andress { get; set; }
        //xet trong csdl xem có trùng UserName không
        [Remote(action: "VerifyUserName", controller: "Users", AdditionalFields = nameof(UserName))]
        public string UserName{ get; set; }
        public string PassWord { get; set; }
        public int TrangThai { get; set; }
        public int MAQuyen { get; set; }
        [ForeignKey("MAQuyen")]
        public virtual PhanQuyenModel PhanQuyens { get; set; }
        public ICollection<HoaDonModel> HoaDons { get; set; }
        public ICollection<DanhGiaModel> danhGias { get; set; }

    }
}
