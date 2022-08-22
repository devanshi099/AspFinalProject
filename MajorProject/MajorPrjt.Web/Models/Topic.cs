﻿using Microsoft.AspNetCore.Identity;
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
        [Display(Name = "Topic ID")]
        public int TopicId { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        [MaxLength(50, ErrorMessage = "{0} can contain a maximum of {1} characters")]
        [MinLength(2, ErrorMessage = "{0} should contain a minimum of {1} characters")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Numbers are not allowed. Please use only alphabets!!!")]
        public string Title { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Description { get; set; }


        [Required]
        [DefaultValue(true)]
        [Display(Name = "Is Answered?")]
        public bool IsAnswered { get; set; }


        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime PostDateTime { get; set; }


        #region Navigation Properties to Comment Model
        public ICollection<Comment> Comments { get; set; }
        #endregion

        //public ApplicationUser ApplicationUser { get; set; }
    }
}