using Laboratorul5.Data;
using Laboratorul5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorul5.Controllers;

    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var categories = from categ in _db.Categories
                select categ;

            ViewBag.Categories = categories;

            return View();
        }

        public ActionResult Show(int id)
        {
            Category categ = _db.Categories.Find(id);

            ViewBag.Category = categ;

            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Category categ)
        {
            try
            {
                _db.Categories.Add(categ);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            Category categ = _db.Categories.Find(id);

            ViewBag.Categories = categ;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Category requestCateg)
        {
            Category categ = _db.Categories.Find(id);

            try
            {
                categ.CategoryName = requestCateg.CategoryName;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Edit", categ.Id);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Category categ = _db.Categories.Find(id);

            _db.Categories.Remove(categ);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

