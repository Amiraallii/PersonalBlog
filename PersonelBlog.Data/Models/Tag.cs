using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Models
{
    [Table("Tag", Schema = "dbo")]
    public class Tag
    {
        [Key]
        public long TagId { get; set; }
        [Required(ErrorMessage ="please enter tag title!")]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage ="please enter tag meta title!")]
        public string MetaTitle { get; set; }
        [StringLength(50)]
        public string Slug { get; set; }
        [StringLength(100)]
        public string Content { get; set; }
    }
}
