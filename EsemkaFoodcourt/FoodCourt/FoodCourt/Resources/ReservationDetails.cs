//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodCourt.Resources
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReservationDetails
    {
        public int ID { get; set; }
        public int ReservationID { get; set; }
        public int MenuID { get; set; }
        public int Qty { get; set; }
    
        public virtual Menus Menus { get; set; }
        public virtual Reservations Reservations { get; set; }
    }
}
