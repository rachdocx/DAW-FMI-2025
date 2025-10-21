using Microsoft.AspNetCore.Mvc;
using Laborator4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laborator4.Controllers
{
    public class ArticlesController : Controller
    {
        private static List<Article> articles = new List<Article>();

        [NonAction]
        public Article[] GetArticles()
        {
            if (articles.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    articles.Add(new Article
                    {
                        Id = i + 1,
                        Title = "Articol " + (i + 1),
                        Content = "Conținut articol " + (i + 1),
                        Date = DateTime.Now
                    });
                }
            }

            return articles.ToArray();
        }


        [HttpGet]
        public IActionResult Index()
        {
            var allArticles = GetArticles();
            return View(allArticles);
        }



        [HttpGet]
        public IActionResult Show(int id)
        {
            var article = GetArticles().FirstOrDefault(a => a.Id == id);

            if (article == null)
                return NotFound();

            return View(article);
        }


        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Article article)
        {

            article.Id = articles.Count > 0 ? articles.Max(a => a.Id) + 1 : 1;
            article.Date = DateTime.Now;
            articles.Add(article);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var article = articles.FirstOrDefault(a => a.Id == id);

            if (article == null)
                return NotFound();

            return View(article);
        }

        [HttpPost]
        public IActionResult Edit(int id, Article updatedArticle)
        {
            var article = articles.FirstOrDefault(a => a.Id == id);

            if (article == null)
                return NotFound();

            article.Title = updatedArticle.Title;
            article.Content = updatedArticle.Content;
            article.Date = DateTime.Now;

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var article = articles.FirstOrDefault(a => a.Id == id);

            if (article == null)
                return NotFound();

            articles.Remove(article);
            return RedirectToAction("Index");
        }
    }
}
