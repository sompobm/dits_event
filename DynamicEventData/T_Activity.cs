//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dynamic_Event_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Activity
    {
        public string BarcodeNo { get; set; }
        public string ActivityNo { get; set; }
        public Nullable<System.DateTime> ActivityDateTime { get; set; }
        public string CreatedUser { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual M_Barcode M_Barcode { get; set; }
    }
}
