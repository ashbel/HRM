using Microsoft.AspNetCore.Identity;

namespace Hrm_SystemCore.Models;

public class Users : IdentityUser
{
    public int EmployeeId { get; set; }
    public virtual tblEmployee Employee { get; set; }
}