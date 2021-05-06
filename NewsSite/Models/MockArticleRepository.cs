using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    public class MockArticleRepository : IArticleRepository
    {
        private List<Article> articles;

        public MockArticleRepository()
        {
            articles = new List<Article>()
            {
                //new Article(){Id = 1, Title = "Big mistake at local bank", Author = "Henk Smits", Content = "Local bank gave away all its money. Big software bug was probably the cause of it! Very sad..."},
                //new Article(){Id = 2, Title = "Flower power", Author = "Maya Bee", Content = "The nature club located in Someren has planted over a thousand flowers in Vendoven Central park. Locals say that it looks beautiful. "},
                //new Article(){Id = 3, Title = "New Tesla Truck", Author = "Cindy Smave", Content = "Tesla is going to announce their new truck in the upcoming weeks. It should be one of the most powerful trucks yet in existence!"}
            };
        }

        public Article Add(Article article)
        {
            article.Id = articles.Count + 1;
            articles.Add(article);
            return article;
        }

        public Article Delete(int Id)
        {
            Article found = null;
            foreach (Article a in articles)
            {
                if (a.Id == Id) { found = a; break; }
            }
            if(found != null)
            {
                articles.Remove(found);
            }
            return found;
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return articles;
        }

        public IEnumerable<Article> GetAllArticlesNoTracking()
        {
            return articles;
        }

        public Article GetArticle(int Id)
        {
            foreach(Article a in articles)
            {
                if(a.Id == Id) { return a; }
            }
            return null;
        }

        public Article Update(Article articleChanges)
        {
            Article found = null;
            foreach (Article a in articles)
            {
                if (a.Id == articleChanges.Id) { found = a; break; }
            }
            if (found != null)
            {
                found.Title = articleChanges.Title;
                //found.Author = articleChanges.Author;
                found.Content = articleChanges.Content;
            }
            return found;
        }

    }
}
