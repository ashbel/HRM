//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hrm_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblWorkshift
    {
        public tblWorkshift()
        {
            this.tblWkshftLinks = new HashSet<tblWkshftLink>();
        }
    
        public int wkshft_id { get; set; }
        public string wkshft_title { get; set; }
        public Nullable<int> wkshft_hrs { get; set; }
        public Nullable<System.TimeSpan> wkshft_from { get; set; }
        public Nullable<System.TimeSpan> wkshft_to { get; set; }
        public Nullable<System.TimeSpan> wkshft_lunch_from { get; set; }
        public Nullable<System.TimeSpan> wkshft_lunch_to { get; set; }
        public Nullable<System.TimeSpan> wkshft_brk_from { get; set; }
        public Nullable<System.TimeSpan> wkshft_brk_to { get; set; }
        public Nullable<System.TimeSpan> wkshft_xtrabrk_from { get; set; }
        public Nullable<System.TimeSpan> wkshft_xtrabrk_to { get; set; }
        public string wkshft_notes { get; set; }
        public int inputter { get; set; }
        public System.DateTime create_date { get; set; }
    
        public virtual ICollection<tblWkshftLink> tblWkshftLinks { get; set; }
    }
}
