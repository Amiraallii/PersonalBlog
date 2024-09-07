using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Models
{
    [Table("PostComment", Schema = "dbo")]
    public class PostComment
    {
        [Key]
        public long CommentId { get; set; }
        public long PostId { get; set; }
        public long ParentId { get; set; }
        public byte Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PublishDate { get; set; }
        [Required(ErrorMessage ="Please enter the title!")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage ="please write your comment!")]
        [StringLength(400)]
        public string Content { get; set; }
    }
}
