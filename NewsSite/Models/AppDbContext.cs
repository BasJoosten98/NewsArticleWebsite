using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
              
        }

        public DbSet<Article> Articles { get; set; }

        //seeding db with articles
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Article>().HasData(
            //    new Article() { Id = 1, Title = "Big mistake at local bank", Author = "Henk Smits", Content = "Local bank gave away all its money. Big software bug was probably the cause of it! Very sad..." },
            //    new Article() { Id = 2, Title = "Flower power", Author = "Maya Bee", Content = "The nature club located in Someren has planted over a thousand flowers in Vendoven Central park. Locals say that it looks beautiful. " },
            //    new Article() { Id = 3, Title = "New Tesla Truck", Author = "Cindy Smave", Content = "Tesla is going to announce their new truck in the upcoming weeks. It should be one of the most powerful trucks yet in existence!" }
            //    );
        }
    }
}
