using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MajorPrjt.Web.Models
{
    //public class ApplicationUser : IdentityUser
    //{
    //    public List<Topic> Topics { get; set; }
    //}
    [Table("Topics")]
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int TopicId { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        [MaxLength(50, ErrorMessage = "{0} can contain a maximum of {1} characters")]
        [MinLength(2, ErrorMessage = "{0} should contain a minimum of {1} characters")]
        public string Title { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Question")]
        public string Description { get; set; }


        [Required]
        [DefaultValue(true)]
        [Display(Name = "Is Answered?")]
        public bool IsAnswered { get; set; }


        [Required]
        [Display(Name = "Date & Time")]
       
        public DateTime PostDateTime { get; set; } 



        [Display(Name = "Posted By")]
        public string CreatedBy { get; set; }


        #region Navigation Properties to Comment Model
        public ICollection<Comment> Comments { get; set; }
        #endregion


        #region Navigation Properties to Category Model
        [Display(Name = "Select Category")]
        public short CategoryId { get; set; }

        [ForeignKey(nameof(Topic.CategoryId))]
        public Category Category { get; set; }
        #endregion

        //public ApplicationUser ApplicationUser { get; set; }
    }
}
