using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Models
{
    [Table("PostTag", Schema = "dbo")]
    public class PostTag
    {
        [Key]
        public long Id { get; set; }
        public long PostId { get; set; }
        public long TagId { get; set; }
    }
}
