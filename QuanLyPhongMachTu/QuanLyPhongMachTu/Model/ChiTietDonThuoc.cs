//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyPhongMachTu.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDonThuoc
    {
        public string MaDonThuoc { get; set; }
        public string MaThuoc { get; set; }
        public string SoLuong { get; set; }
        public string CachDung { get; set; }
    
        public virtual DonThuoc DonThuoc { get; set; }
        public virtual Thuoc Thuoc { get; set; }
    }
}
