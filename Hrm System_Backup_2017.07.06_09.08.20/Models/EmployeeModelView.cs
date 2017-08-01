using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hrm_System.Models
{
    public class EmployeeModelView
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_mid_names { get; set; }
        public string emp_lname { get; set; }
        public string emp_email { get; set; }
        public Nullable<int> emp_branch { get; set; }
        public Nullable<int> emp_dpt { get; set; }
        public Nullable<int> emp_status { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime emp_bDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> emp_jDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> emp_cDate { get; set; }
        public Nullable<int> emp_pos_id { get; set; }
        public string emp_id_num { get; set; }
        public string emp_ec_num { get; set; }
        public string emp_nation { get; set; }
        public string emp_strt { get; set; }
        public string emp_nghbhd { get; set; }
        public string emp_phone { get; set; }
        public string emp_mobile { get; set; }
        public string emp_kin { get; set; }
        public string emp_kin_add { get; set; }
        public string emp_kin_ph { get; set; }
        public string emp_kin_rel { get; set; }
        public Nullable<int> emp_state { get; set; }
        public Nullable<int> img_id { get; set; }
        public Nullable<int> emp_sex { get; set; }
        public Nullable<int> emp_marital { get; set; }
        public Nullable<int> emp_salutation { get; set; }
        public Nullable<int> emp_city { get; set; }
        public Nullable<int> emp_province { get; set; }
        public string emp_passport_num { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> emp_passport_date { get; set; }
        public string emp_drv_num { get; set; }


        public virtual tblBranch tblBranch { get; set; }
        public virtual tblDepartment tblDepartment { get; set; }
        public virtual tblEmployeeStatu tblEmployeeStatu { get; set; }
        public virtual ICollection<tblPositionHistory> tblPositionHistories { get; set; }
        public virtual ICollection<tblUser> tblUsers { get; set; }
        public virtual tblPosition tblPosition { get; set; }
        public virtual ICollection<tblEmployeeContact> EmployeeContacts { get; set; }
        public virtual tblEmployee tblEmployees1 { get; set; }
        public virtual tblEmployee tblEmployee1 { get; set; }
        public virtual tblEmplStatu tblEmplStatu { get; set; }
        public virtual tblImage tblImage { get; set; }
        public virtual ICollection<tblLeave> tblLeaves { get; set; }
        public virtual ICollection<tblLvUsage> tblLvUsages { get; set; }
        public virtual tblMarital tblMarital { get; set; }
        public virtual tblGender tblGender { get; set; }
        public virtual tblSalutation tblSalutation { get; set; }
        public virtual tblProvince tblProvince { get; set; }
        public virtual tblCity tblCity { get; set; }
    }
}