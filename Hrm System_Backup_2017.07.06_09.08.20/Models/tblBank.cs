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
    
    public partial class tblBank
    {
        public tblBank()
        {
            this.tblPayrolls = new HashSet<tblPayroll>();
        }
    
        public int bnk_id { get; set; }
        public string bnk_name { get; set; }
        public string bnk_code { get; set; }
    
        public virtual ICollection<tblPayroll> tblPayrolls { get; set; }
    }
}
