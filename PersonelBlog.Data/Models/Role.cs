using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Models
{
    [Table("Role", Schema = "dbo")]
    public class Role
    {
        [Key]
        public long  RoleI { get; set; }
        [Required(ErrorMessage ="Please enter the role title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage ="please enter a brief about the role access")]
        [StringLength (150)]
        public string Description { get; set; }

    }
}
