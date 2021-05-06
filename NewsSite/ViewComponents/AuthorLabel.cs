using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewComponents
{
    public class AuthorLabel : ViewComponent
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthorLabel(IArticleRepository articleRepository, UserManager<ApplicationUser> userManager)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke(
            string authorName
            )
        {
            ViewBag.AuthorLabelName = String.IsNullOrEmpty(authorName) ? "Unknown" : authorName;

            var userQuery = from u in userManager.Users
                            where u.UserName == authorName
                            select u.Id;

            string userId = userQuery.FirstOrDefault();

            if (String.IsNullOrEmpty(userId))
            {
                ViewBag.AuthorLabelStats = "No information could be found about this author...";
            }
            else
            {
                var articles = from a in articleRepository.GetAllArticlesNoTracking()
                                   where a.UserId == userId
                                   select a;

                ViewBag.AuthorLabelStats = "This author has written " + articles.Count() + " articles!";
            }

            return View();
        }
    }
}
