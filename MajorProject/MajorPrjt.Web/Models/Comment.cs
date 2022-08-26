using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MajorPrjt.Web.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int CommentId { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Comment")]
        public string CommentDescription { get; set; }



        [Display(Name = "Commented By")]
        public string CommentedBy { get; set; }


        [Required]
        [Display(Name = "Date & Time")]
        [Column(TypeName = "datetime2")]
        public DateTime CommentDateTime { get; set; }



        #region Navigation Properties to Topic Model
        [Display(Name = "Select Question")]
        public int TopicId { get; set; }

        [ForeignKey(nameof(Comment.TopicId))]
        public Topic Topic { get; set; }
        #endregion



        #region Navigation Properties to Reply Model
        public ICollection<Reply> Replies { get; set; }
        #endregion
    }
}
