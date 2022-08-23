using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MajorPrjt.Web.Models
{
    [Table("Replies")]
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Reply ID")]
        public int ReplyId { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Reply")]
        public string ReplyDescription { get; set; }



        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ReplyDateTime { get; set; }


        [Display(Name = "Replied By")]
        public string RepliedBy { get; set; }


        #region Navigation Properties to Comment Model
        [Display(Name = "Comment")]
        public int CommentId { get; set; }

        [ForeignKey(nameof(Reply.CommentId))]
        public Comment Comment { get; set; }
        #endregion
    }
}
