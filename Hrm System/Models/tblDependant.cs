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
    
    public partial class tblDependant
    {
        public int dep_id { get; set; }
        public Nullable<int> emp_id { get; set; }
        public string dep_name { get; set; }
        public Nullable<System.DateTime> dep_dob { get; set; }
        public string dep_rltn { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}