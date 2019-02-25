using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Blogs = new HashSet<Blogs>();
        }

        [Key]
        [StringLength(10)]
        public string CategoryId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(5)]
        public string Status { get; set; }

        [InverseProperty("CategoryNavigation")]
        public virtual ICollection<Blogs> Blogs { get; set; }
    }
}