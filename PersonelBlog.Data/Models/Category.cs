using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Models
{
    [Table("Category", Schema = "dbo")]
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        [ForeignKey(name:"Category")]
        public Nullable<long> ParentId { get; set; }
        [Required(ErrorMessage ="Please Enter the title for category!")]
        [StringLength(50)]
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
    }
}
