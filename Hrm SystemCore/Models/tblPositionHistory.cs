//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Hrm_SystemCore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPositionHistory
    {
        [Key]
        public int ph_id { get; set; }
        public Nullable<int> emp_id { get; set; }
        public Nullable<int> pos_id { get; set; }
        public Nullable<int> dpt_id { get; set; }
        public Nullable<decimal> ph_sal { get; set; }
        public Nullable<int> br_id { get; set; }
        public Nullable<System.DateTime> ph_sDate { get; set; }
        public Nullable<System.DateTime> ph_eDate { get; set; }
    
        public virtual tblBranch tblBranch { get; set; }
        public virtual tblDepartment tblDepartment { get; set; }
        public virtual tblEmployee tblEmployee { get; set; }
        public virtual tblPosition tblPosition { get; set; }
    }
}
