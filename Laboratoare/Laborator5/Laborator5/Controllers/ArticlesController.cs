using Laborator5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // NECESAR pentru .Include()

namespace Laborator5.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly AppDbContext _db;

        public ArticlesController(AppDbContext context)
        {
            _db = context;
        }

        // READ - Toate articolele (Index)
        public IActionResult Index()
        {
            // IMPORTANT: Folosim .Include(a => a.Category) pentru a prelua și numele categoriei
            var articles = _db.Articles.Include(a => a.Category).OrderBy(a => a.Title);

            ViewBag.Articles = articles;

            return View();
        }

        // READ - Detalii articol (Show)
        public ActionResult Show(int id)
        {
            // Preluăm articolul ȘI categoria asociată
            Article? article = _db.Articles.Include(a => a.Category)
                                          .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            ViewBag.Article = article;

            return View();
        }

        // CREATE - Afișarea formularului (New GET)
        public IActionResult New()
        {
            // Trimitem lista de categorii către View pentru dropdown list
            ViewBag.Categories = _db.Categories.OrderBy(c => c.CategoryName).ToList();
            
            // Recomandat: Trimiterea unui model gol, nu doar a unui ViewBag
            return View();
        }

        // CREATE - Salvarea noului articol (New POST)
        [HttpPost]
        public IActionResult New(Article article)
        {
            // Setează data curentă automat
            article.Date = DateTime.Now;

            // Verificăm dacă modelul este valid (inclusiv CategoryId)
            if (ModelState.IsValid)
            {
                _db.Articles.Add(article);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            // Dacă eșuează validarea, reîncărcăm categoriile și View-ul
            ViewBag.Categories = _db.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(article);
        }

        // UPDATE - Afișarea formularului de editare (Edit GET)
        public IActionResult Edit(int id)
        {
            Article? article = _db.Articles.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            // Trimitem articolul curent și lista de categorii
            ViewBag.Article = article;
            ViewBag.Categories = _db.Categories.OrderBy(c => c.CategoryName).ToList();

            return View();
        }

        // UPDATE - Salvarea modificărilor (Edit POST)
        [HttpPost]
        public ActionResult Edit(int id, Article requestArticle)
        {
            Article? article = _db.Articles.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            // Setăm Category la null pentru a evita excepții de urmărire (tracking)
            requestArticle.Category = null; 
            
            try
            {
                // Actualizăm doar câmpurile necesare
                article.Title = requestArticle.Title;
                article.Content = requestArticle.Content;
                article.CategoryId = requestArticle.CategoryId;
                article.Date = DateTime.Now; // Opțional: actualizăm data la modificări

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // În caz de eroare, retrimitem View-ul cu datele și categoriile
                ViewBag.Categories = _db.Categories.OrderBy(c => c.CategoryName).ToList();
                return View(article);
            }
        }

        // DELETE - Ștergerea articolului (Delete POST)
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Article? article = _db.Articles.Find(id);

            if(article != null)
            {
                _db.Articles.Remove(article);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                // Folosim codul de status standard 404 (Not Found)
                return NotFound(); 
            } 
        }
    }
}