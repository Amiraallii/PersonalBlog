using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Models
{
    [Table("Post", Schema = "dbo")]
    public class Post
    {
        [Key]
        public long PostId { get; set; }
        [ForeignKey(name:"UserId")]
        [Required]
        public long Author { get; set; }
        [ForeignKey(name:"SubjectId")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage ="please enter a title!")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage ="please enter meta title")]
        [StringLength(150)]
        public string MetaTitle { get; set; }
        [StringLength(50)]
        public string Slug { get; set; }
        public byte Published { get; set; }
        [Required(ErrorMessage ="enter a brief about content")]
        [StringLength(150)]
        public string Summary { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PublishDate { get; set; }
        [Required(ErrorMessage ="please enter content!!!!")]
        public string Content { get; set; }
    }
}
