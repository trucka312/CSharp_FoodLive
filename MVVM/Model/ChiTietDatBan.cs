//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodeLive.MVVM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDatBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietDatBan()
        {
            this.ThongBaos = new HashSet<ThongBao>();
        }
    
        public string MaDatBan { get; set; }
        public string MaBanAn { get; set; }
        public string NguoiDat { get; set; }
        public string SoDienThoai { get; set; }
        public string GhiChu { get; set; }
        public Nullable<byte> TrangThai { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public string email { get; set; }
    
        public virtual BanAn BanAn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBao> ThongBaos { get; set; }
        public virtual user user { get; set; }
    }
}