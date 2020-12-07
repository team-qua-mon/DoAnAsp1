﻿using System;
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
        public string TenQuyen { get; set; }
        public string ChiTiet { get; set; }
        public ICollection<NguoiDungModel> nguoiDungs { get; set; }
    }
}