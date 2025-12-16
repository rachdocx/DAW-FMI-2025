using ArticlesApp.Models;
using ArticlesAppLab6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticlesAppLab6.Controllers
{
    public class ArticlesController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext db = context;

        // Se afiseaza lista tuturor articolelor impreuna cu categoria 
        // din care fac parte
        // HttpGet implicit
        public IActionResult Index()
        {
            

            //SAU
            /*
            var articles = from article in db.Articles.Include("Category")
                           orderby article.Date descending
                           select article;
            
            */

           

            return View();
        }

        // Se afiseaza un singur articol in functie de id-ul sau 
        // impreuna cu categoria din care face parte
        // In plus sunt preluate si toate comentariile asociate unui articol
        // HttpGet implicit
        public IActionResult Show(int id)
        {
            Article article = db.Articles
                            .Include(a => a.Category)
                            .Include(a => a.Comments)
                            .Where(a => a.Id == id)
                            .First();


            /*
            Article article = (from art in db.Articles.Include("Category").Include("Comments")
                              where art.Id == id
                              select art).First();

            */

            if (article == null)
            {
                return NotFound();
            }

            ViewBag.Article = article;

            ViewBag.Category = article.Category;

            // ViewBag.Category(ViewBag.UnNume) = article.Category (proprietatea Category);

            return View();
        }


        // Se afiseaza formularul in care se vor completa datele unui articol
        // impreuna cu selectarea categoriei din care face parte
        // HttpGet implicit

        public IActionResult New()
        {
            var categories = from categ in db.Categories
                             select categ;

            ViewBag.Categories = categories;

            return View();
        }

        // Se adauga articolul in baza de date
        [HttpPost]
        public IActionResult New(Article article)
        {
            try
            {
                article.Date = DateTime.Now;
                db.Articles.Add(article);

                db.SaveChanges();
                return RedirectToAction("Index");
                //  return Redirect("/Articles/Index"); 
            }

            catch (Exception)
            {
                return RedirectToAction("New");
            }
        }

        /*

        // Se editeaza un articol existent in baza de date impreuna cu categoria din care face parte
        // Categoria se selecteaza dintr-un dropdown
        // HttpGet implicit
        // Se afiseaza formularul impreuna cu datele aferente articolului din baza de date
        public IActionResult Edit(int id)
        {
            

            return View();
        }

        // Se adauga articolul modificat in baza de date
        [HttpPost]
        public IActionResult Edit(int id, Article requestArticle)
        {
            

            try
            {
                
              
            }

            catch (Exception)
            {
                
               
            }
        }

        */

        // Se sterge un articol din baza de date 
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Article? article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

