using MajorPrjt.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MajorPrjt.Web.Areas.User.ViewModels
{
    public class UserForumViewModel
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public ICollection<Topic> Topics { get; set; }
    }
}
