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
    
    public partial class tblCourseType
    {
        public tblCourseType()
        {
            this.tblCourses = new HashSet<tblCours>();
        }

        [Key]
        public int type_id { get; set; }
        public string type_name { get; set; }
        public string typ_descr { get; set; }
    
        public virtual ICollection<tblCours> tblCourses { get; set; }
    }
}
