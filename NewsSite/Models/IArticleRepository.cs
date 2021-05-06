using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    public interface IArticleRepository
    {
        Article GetArticle(int Id);
        IEnumerable<Article> GetAllArticles();
        Article Add(Article article);
        Article Update(Article articleChanges);
        Article Delete(int Id);
        IEnumerable<Article> GetAllArticlesNoTracking();
    }
}
