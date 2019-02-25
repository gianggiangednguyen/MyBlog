using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public partial class Blogs
    {
        [Key]
        [StringLength(10)]
        public string BlogId { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [Column("Content_")]
        public string Content { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreate { get; set; }
        [StringLength(10)]
        public string Category { get; set; }
        [Required]
        [StringLength(10)]
        public string UserCreate { get; set; }
        [Required]
        [StringLength(5)]
        public string Status { get; set; }

        [ForeignKey("Category")]
        [InverseProperty("Blogs")]
        public virtual Categories CategoryNavigation { get; set; }
        [ForeignKey("UserCreate")]
        [InverseProperty("Blogs")]
        public virtual Users UserCreateNavigation { get; set; }
    }
}