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
    
    public partial class tblDocument
    {
        [Key]
        public int doc_id { get; set; }
        public string doc_name { get; set; }
        public string doc_path { get; set; }
        public Nullable<int> emp_id { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}
