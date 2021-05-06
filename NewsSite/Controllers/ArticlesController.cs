using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSite.Models;
using NewsSite.ViewModels;
using System.Security.Claims;

namespace NewsSite.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ArticlesController(IArticleRepository ArticleRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            articleRepository = ArticleRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<ViewResult> Index()
        {
            IEnumerable<Article> articles = articleRepository.GetAllArticles();
            List<ArticlesIndexViewModel> model = new List<ArticlesIndexViewModel>();
            foreach(Article a in articles)
            {
                var query = from user in userManager.Users
                            where user.Id == a.UserId
                            select user.UserName;
                var name = await query.FirstOrDefaultAsync();
                ArticlesIndexViewModel vm = new ArticlesIndexViewModel
                {
                    Article = a,
                    AuthorName = name
                };
                model.Add(vm);
            }
            ViewBag.curAuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(model);
        }
        [AllowAnonymous]
        public async Task<ViewResult> article(int Id)
        {
            Article article = articleRepository.GetArticle(Id);

            if(article == null) //no article found with Id
            {
                Response.StatusCode = 404;
                return View("ArticleNotFound");
            }
            var query = from user in userManager.Users
                        where user.Id == article.UserId
                        select user.UserName;
            var name = await query.FirstOrDefaultAsync();

            ArticlesIndexViewModel model = new ArticlesIndexViewModel()
            {
                Article = article,
                AuthorName = name
            };

            ViewBag.Title = article.Title;
            return View(model);

        }
        [HttpGet]
        public ViewResult Create()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ArticlesIndexViewModel model = new ArticlesIndexViewModel()
            {
                Article = new Article()
                {
                    UserId = userId
                }
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ArticlesIndexViewModel submission)
        {
            if (ModelState.IsValid)
            { 
                Article addedArticle = articleRepository.Add(submission.Article);
                return RedirectToAction("article", new { Id = addedArticle.Id });
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            Article model = articleRepository.GetArticle(Id);
            if(model == null)
            {
                Response.StatusCode = 404;
                return View("ArticleNotFound");
            }
            if (!isArticleAuthor(Id))
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Article articleChanges)
        {
            if (!isArticleAuthor(articleChanges.Id))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            if (ModelState.IsValid)
            {
                Article newArticle = articleRepository.Update(articleChanges);
                if (newArticle == null)
                {
                    Response.StatusCode = 404;
                    return View("ArticleNotFound");
                }
                return RedirectToAction("article", new { Id = newArticle.Id });
            }
            return View(articleChanges);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!isArticleAuthor(Id))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            Article deletedArticle = articleRepository.Delete(Id);
            if (deletedArticle == null)
            {
                Response.StatusCode = 404;
                return View("ArticleNotFound");
            }
            return RedirectToAction("index");
        }

        [NonAction]
        public bool isArticleAuthor(int articleId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var query = from article in articleRepository.GetAllArticlesNoTracking()
                        where article.Id == articleId && article.UserId == userId
                        select article;

            var result = query.FirstOrDefault();

            return result != null;
        }
    }
}