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
    
    public partial class LoaiThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiThuoc()
        {
            this.ChiTietDonThuocs = new HashSet<ChiTietDonThuoc>();
        }
    
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public int MaDonVi { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public int SoLanSuDung { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
        public virtual DonVi DonVi { get; set; }
    }
}
