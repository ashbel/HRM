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
    
    public partial class tblEducation
    {
        public int edu_id { get; set; }
        public Nullable<int> emp_id { get; set; }
        public Nullable<int> edu_lvl_id { get; set; }
        public string edu_name { get; set; }
        public string edu_qlfcn { get; set; }
        public string edu_score { get; set; }
        public string edu_comment { get; set; }
        public Nullable<System.DateTime> edu_sdate { get; set; }
        public Nullable<System.DateTime> edu_edate { get; set; }
    
        public virtual tblEduLevel tblEduLevel { get; set; }
        public virtual tblEmployee tblEmployee { get; set; }
    }
}
