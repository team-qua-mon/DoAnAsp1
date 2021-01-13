using DoAnAsp.Areas.ADmin.Valication;
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

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name ="Họ")]
        [StringLength(maximumLength:20,ErrorMessage ="không được nhập quá 20 ký tự")]
        public string Ho { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [StringLength(maximumLength: 20, ErrorMessage = "không được nhập quá 20 ký tự")]
        [Display(Name = "Tên lót")]
        public string TenLot { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [StringLength(maximumLength: 20, ErrorMessage = "không được nhập quá 20 ký tự")]
        [Display(Name = "Tên  người dùng")]
        public string TenND { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }


        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength:20,ErrorMessage ="không được nhập quá 20 ký tự")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [StringLength(maximumLength: 300, ErrorMessage = "Địa Chỉ Dài Hơn 8 Ký Tự", MinimumLength = 8)]
        [Display(Name = "Địa Chỉ")]
        public string Andress { get; set; }

        //kiem tra trung username
        [UniqueUserName]
        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        public string UserName{ get; set; }

        [Required(ErrorMessage = "Vui Lòng Điền Đủ Thông Tin")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public int TrangThai { get; set; }

        public int MAQuyen { get; set; }
        [ForeignKey("MAQuyen")]
        public virtual PhanQuyenModel PhanQuyens { get; set; }
        public ICollection<HoaDonModel> HoaDons { get; set; }
        public ICollection<DanhGiaModel> danhGias { get; set; }

    }
}
