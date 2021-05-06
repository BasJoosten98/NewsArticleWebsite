using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Article> Articles { get; set; }
    }
}
