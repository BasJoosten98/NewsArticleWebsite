using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class ArticlesIndexViewModel
    {
        public string AuthorName { get; set; }

        [Required]
        public Article Article { get; set; }

    }
}
