using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MajorPrjt.Web.Models
{
    
        [Table("Categories")]
        public class Category
        {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "Category ID")]
            public short CategoryId { get; set; }

            [Required(ErrorMessage = "{0} cannot be empty")]
            [MaxLength(50, ErrorMessage = "{0} can contain a maximum of {1} characters")]
            [MinLength(2, ErrorMessage = "{0} should contain a minimum of {1} characters")]
            [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Numbers are not allowed. Please use only alphabets!!!")]
            [Display(Name = "Name of the Category")]
            public string CategoryName { get; set; }


            #region Navigation Properties to Topics Model

            public ICollection<Topic> Topics { get; set; }

            #endregion

        }
    
}
