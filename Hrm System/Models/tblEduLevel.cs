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
    
    public partial class tblEduLevel
    {
        public tblEduLevel()
        {
            this.tblEducations = new HashSet<tblEducation>();
        }
    
        public int edu_lv_id { get; set; }
        public string edu_lv_name { get; set; }
    
        public virtual ICollection<tblEducation> tblEducations { get; set; }
    }
}
