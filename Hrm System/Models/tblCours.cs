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
    
    public partial class tblCours
    {
        public tblCours()
        {
            this.tblTrainings = new HashSet<tblTraining>();
            this.tblTrainingSessions = new HashSet<tblTrainingSession>();
        }
    
        public int course_id { get; set; }
        public string course_nm { get; set; }
        public string course_dur { get; set; }
        public string course_descr { get; set; }
        public int type_id { get; set; }
    
        public virtual tblCourseType tblCourseType { get; set; }
        public virtual ICollection<tblTraining> tblTrainings { get; set; }
        public virtual ICollection<tblTrainingSession> tblTrainingSessions { get; set; }
    }
}
