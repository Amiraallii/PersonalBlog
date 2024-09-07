using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Models
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        public long UserId { get; set; }
        [Required(ErrorMessage ="please enter your first name!")]
        [StringLength(50)]
        public string FName { get; set; }
        [Required(ErrorMessage ="please enter your last name!")]
        [StringLength(50)]
        public string LName { get; set; }
        [Required(ErrorMessage ="please enter your user name!")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="please select your birth date!")]
        public string BirthDate { get; set; }
        [Required(ErrorMessage ="please select your gender!")]
        public bool Gender { get; set; }
        [Required(ErrorMessage ="please enter your Id number!")]
        [StringLength(10)]
        public string IdNumber { get; set; }
        [Required(ErrorMessage ="Please select your marrige status!")]
        public bool Maried { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(UserId))]
        public Nullable<long> CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public Nullable<long> UpdatedId { get; set; }
        public  Nullable<DateTime> LastModified { get; set; }
        public Nullable<DateTime> LastLogin { get; set; }
        [Required(ErrorMessage ="Please enter your email address")]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }
        [NotMapped]
        [Required(ErrorMessage ="please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "please enter your password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
