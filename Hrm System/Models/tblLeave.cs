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
    
    public partial class tblLeave
    {
        public tblLeave()
        {
            this.tblLvUsages = new HashSet<tblLvUsage>();
        }
    
        public int lv_id { get; set; }
        public Nullable<decimal> lv_bal { get; set; }
        public Nullable<int> lvtyp_id { get; set; }
        public Nullable<int> emp_id { get; set; }
        public Nullable<System.DateTime> lv_period { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
        public virtual tblLvType tblLvType { get; set; }
        public virtual ICollection<tblLvUsage> tblLvUsages { get; set; }
    }
}
