using System.ComponentModel.DataAnnotations;
using Hrm_SystemCore.Models;

namespace Hrm_SystemCore.Models
{
    public class EmployeeModelView
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_mid_names { get; set; }
        public string emp_lname { get; set; }
        public string emp_email { get; set; }
        public string emp_branch { get; set; }
        public string emp_dpt { get; set; }
        public string emp_status { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime emp_bDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> emp_jDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> emp_cDate { get; set; }
        public string emp_pos_id { get; set; }
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
        public string emp_state { get; set; }
        public Nullable<int> img_id { get; set; }
        public string emp_sex { get; set; }
        public string emp_marital { get; set; }
        public string emp_salutation { get; set; }
        public string emp_city { get; set; }
        public string emp_province { get; set; }
        public string emp_passport_num { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> emp_passport_date { get; set; }
        public string emp_drv_num { get; set; }
        public string cntrct_title { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> cntrct_sdate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> cntrct_edate { get; set; }
        public string cntrct_state { get; set; }
        public string cntrct_desc { get; set; }
        public string emp_br { get; set; }
        public string emp_dt { get; set; }



        public virtual tblBranch tblBranch { get; set; }
        public virtual tblDepartment tblDepartment { get; set; }
        public virtual tblEmployeeStatu tblEmployeeStatu { get; set; }
        public virtual ICollection<tblPositionHistory> tblPositionHistories { get; set; }
        public virtual ICollection<tblUser> tblUsers { get; set; }
        public virtual tblPosition tblPosition { get; set; }
        public virtual ICollection<tblEmployeeContact> EmployeeContacts { get; set; }
        public virtual tblEmployee tblEmployees { get; set; }
        public virtual tblEmplStatu tblEmplStatu { get; set; }
        public virtual tblImage tblImage { get; set; }
        public virtual ICollection<tblLeave> tblLeaves { get; set; }
        public virtual ICollection<tblLvUsage> tblLvUsages { get; set; }
        public virtual tblMarital tblMarital { get; set; }
        public virtual tblGender tblGender { get; set; }
        public virtual tblSalutation tblSalutation { get; set; }
        public virtual tblProvince tblProvince { get; set; }
        public virtual tblCity tblCity { get; set; }
        public virtual tblContract tblContracts { get; set; }
        public virtual tblContractType tblContractTypes { get; set; }

    }
}