using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public partial class Users
    {
        public Users()
        {
            Blogs = new HashSet<Blogs>();
        }

        [Key]
        [StringLength(10)]
        public string UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreate { get; set; }
        [Required]
        [StringLength(5)]
        public string Status { get; set; }

        [InverseProperty("UserCreateNavigation")]
        public virtual ICollection<Blogs> Blogs { get; set; }
    }
}