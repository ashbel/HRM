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
    
    public partial class tblSalutation
    {
        public tblSalutation()
        {
            this.tblEmployees = new HashSet<tblEmployee>();
        }

        [Key]
        public int sal_id { get; set; }
        public string sal_title { get; set; }
    
        public virtual ICollection<tblEmployee> tblEmployees { get; set; }
    }
}
