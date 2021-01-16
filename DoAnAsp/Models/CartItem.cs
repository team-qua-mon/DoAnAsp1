using DoAnAsp.Areas.ADmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnAsp.Models
{
    [Serializable]
    public class CartItem
    {
        public SanPhamModel SanPham { get; set; }
        public int Quality { get; set; }
        public int Total { get; set; }
        
    }
}
