using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Title can not be longer than 50 characters")]
        public string Title { get; set; }

        //[Required]
        //[MaxLength(25, ErrorMessage ="Author name can not be longer than 25 characters")]
        //[Display(Name = "Author name")]
        //public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
