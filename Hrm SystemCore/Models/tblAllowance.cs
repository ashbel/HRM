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
    
    public partial class tblAllowance
    {
        public tblAllowance()
        {
            this.tblAllowanceLnks = new HashSet<tblAllowanceLnk>();
        }

        [Key]
        public int allowance_id { get; set; }
        public string allowance_name { get; set; }
        public Nullable<decimal> allowance_value { get; set; }
        public string allowance_perc { get; set; }
        public string allowance_desc { get; set; }
    
        public virtual ICollection<tblAllowanceLnk> tblAllowanceLnks { get; set; }
    }
}
