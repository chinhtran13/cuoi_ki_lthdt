//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quan_ly_ban_hang
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHang_Muc
    {
        public int IDoi { get; set; }
        public Nullable<int> IDOrderDetail { get; set; }
        public Nullable<int> IDFood { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual ChiTietDonHang ChiTietDonHang { get; set; }
        public virtual FOOD FOOD { get; set; }
    }
}