//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimePunchDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimePunch
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public string Date { get; set; }
        public string PunchIn { get; set; }
        public string LunchStart { get; set; }
        public string LunchEnd { get; set; }
        public string PunchOut { get; set; }
        public long isOpen { get; set; }
    
        public virtual User User { get; set; }
    }
}
