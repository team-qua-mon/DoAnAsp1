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
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime d = DateTime.Now;
            if (value != null)
            {
                var nhapdate = Convert.ToDateTime(value);
                if (nhapdate < d)
                {
                    return new ValidationResult(Error(d.ToString()));
                }
            }
            return ValidationResult.Success;
        }

        public string Error(string username)
        {
            return $"ngày bắt đầu phải lớn hơn hôm nay {username}";
        }
    }
}
