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
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Comment")]
        public string CommentDescription { get; set; }



        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CommentDateTime { get; set; }



        #region Navigation Properties to Topic Model
        [Display(Name = "Select Topic")]
        public int TopicId { get; set; }

        [ForeignKey(nameof(Comment.TopicId))]
        public Topic Topic { get; set; }
        #endregion



        #region Navigation Properties to Reply Model
        public ICollection<Reply> Replies { get; set; }
        #endregion
    }
}
