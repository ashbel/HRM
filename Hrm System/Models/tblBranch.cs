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
    
    public partial class tblBranch
    {
        public tblBranch()
        {
            this.tblEmployees = new HashSet<tblEmployee>();
            this.tblPositionHistories = new HashSet<tblPositionHistory>();
            this.tblContracts = new HashSet<tblContract>();
        }
    
        public int br_id { get; set; }
        public string br_name { get; set; }
        public string br_address { get; set; }
        public string br_contact { get; set; }
        public string br_descr { get; set; }
    
        public virtual ICollection<tblEmployee> tblEmployees { get; set; }
        public virtual ICollection<tblPositionHistory> tblPositionHistories { get; set; }
        public virtual ICollection<tblContract> tblContracts { get; set; }
    }
}
