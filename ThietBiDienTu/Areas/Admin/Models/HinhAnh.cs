﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThietBiDienTu.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HinhAnh
    {
        public HinhAnh()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public int MaHinhAnh { get; set; }
        
        public string LinkHinhAnhChinh { get; set; }
        
        public string LinkHinhAnhPhu1 { get; set; }
        
        public string LinkHinhAnhPhu2 { get; set; }
        
        public string LinkHinhAnhPhu3 { get; set; }
    
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
