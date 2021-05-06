using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    public class SQLArticleRepository : IArticleRepository
    {
        private readonly AppDbContext context;

        public SQLArticleRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Article Add(Article article)
        {
            context.Articles.Add(article);
            context.SaveChanges();
            return article;
        }

        public Article Delete(int Id)
        {
            Article found = context.Articles.Find(Id);
            if(found != null)
            {
                context.Articles.Remove(found);
                context.SaveChanges();
            }
            return found;
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return context.Articles;
        }

        public IEnumerable<Article> GetAllArticlesNoTracking()
        {
            return context.Articles.AsNoTracking();
        }

        public Article GetArticle(int Id)
        {
            return context.Articles.Find(Id);
        }

        public Article Update(Article articleChanges)
        {
            /*
             * This can cause an error if the article
             * is already been attached and being tracked.
             * If the article is not attached yet then this
             * approach will work.
             */ 
            //var found = context.Articles.Attach(articleChanges);
            //found.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //context.SaveChanges();
            context.Update(articleChanges);
            context.SaveChanges();
            return articleChanges;
        }
    }
}
