//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HOVHOSPITAL3
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment_detail
    {
        public int id { get; set; }
        public int payment_id { get; set; }
        public string item { get; set; }
        public decimal nominal { get; set; }
        public string notes { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> last_updated_at { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    
        public virtual payment payment { get; set; }
    }
}
