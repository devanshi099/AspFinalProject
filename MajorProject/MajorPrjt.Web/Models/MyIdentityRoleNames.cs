
using System.ComponentModel.DataAnnotations;

namespace MajorPrjt.Web.Models
{
    public enum MyIdentityRoleNames
    {

        [Display(Name = "Admin Role")]
        AppAdmin,


        [Display(Name = "User Role")]
        AppUser

    }
}
