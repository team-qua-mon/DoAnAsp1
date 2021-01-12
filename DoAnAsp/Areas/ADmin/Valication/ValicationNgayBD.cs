using DoAnAsp.Areas.ADmin.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Valication
{
    public class ValicationNgayBD: ValidationAttribute
    {
        DateTime d = DateTime.Now;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (DPContext)validationContext.GetService(typeof(DPContext));
            //var ngayBD = _context.KhuyenMais.Single(ng=>ng.NgayBD>)
            return ValidationResult.Success;
        }

        public string BaoLoi(string username)
        {
            return $"username{username} đã tồn tại";
        }
    }
}
