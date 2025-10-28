using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace lab4.Controllers
{ public class ArticlesController : Controller
    {
        [NonAction]
        public Article[] GetArticles()
        {
            Article[] articles = new Article[3];
            for (int i = 0; i < 3; i++)
            {
                Article article = new Article();
                article.Id = i;
                article.Title = "Articol " + (i + 1).ToString();
                article.Content = "Continut articol " + (i + 1).ToString();
                article.Date = DateTime.Now;
                // Se adauga articolul in array
                articles[i] = article;
            }
            return articles;
        }
        //Metoda index are get implicit
        //[HttpGet]
        public IActionResult Index()

        {
            Article[] articles = GetArticles(); 
            ViewBag.Articole = articles;

            //returneaza view-ul numit Index(acelasi nume ca metoda)

            return View();
        }
        //executa get implicit
        public IActionResult Show(int? id)
        {
            Article[] articles = GetArticles();
            try
            {
                ViewBag.Articol= articles[(int)id];
                return View();

            }
            catch (Exception E)
            {

                return StatusCode(StatusCodes.Status404NotFound);

                //return View("Error");
            }
            
            
        }
        [HttpGet]
        public IActionResult New()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult New(Article art)
        {   
            //..cod reare articol in baza de date
            return Content("New Post");
        }
    }
}
