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
        public int MaDT { get; set; }
        public int MaThuoc { get; set; }
        public int SoLuong { get; set; }
        public int MaCachDung { get; set; }
    
        public virtual CachDung CachDung { get; set; }
        public virtual DonThuoc DonThuoc { get; set; }
        public virtual LoaiThuoc LoaiThuoc { get; set; }
    }
}
