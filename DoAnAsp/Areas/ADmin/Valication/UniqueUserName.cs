using DoAnAsp.Areas.ADmin.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Areas.ADmin.Valication
{
    public class UniqueUserName:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (DPContext)validationContext.GetService(typeof(DPContext));
            if(value==null)
            {
                return new ValidationResult(BaoLoi1());
            }
            else
            {
                var entity = _context.NguoiDungs.SingleOrDefault(u => u.UserName == value.ToString());
                if (entity!=null)
                {
                    return new ValidationResult(BaoLoi(value.ToString()));
                }
                return ValidationResult.Success;
            }
            
        }
        
        public string BaoLoi(string username)
        {
            return $"Username {username} đã tồn tại";
        }
        public string BaoLoi1()
        {
            return $"Username";
        }
    }
}
