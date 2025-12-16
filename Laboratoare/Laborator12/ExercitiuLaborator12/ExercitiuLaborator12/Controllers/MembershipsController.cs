﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExercitiuLaborator12.Models;

namespace ExercitiuLaborator12.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly AppDbContext _context;

        public MembershipsController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var abonamente = _context.Membership.Include(a => a.Gym).ToList();
            return View(abonamente);
        }
        public IActionResult New()
        {
            ViewBag.GymList = GetAllGyms();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Membership abonament)
        {
            if (ModelState.IsValid)
            {
                abonament.DataEmitere = DateTime.Now;
                _context.Membership.Add(abonament);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GymList = GetAllGyms();
            return View(abonament);
        }
        
        public IActionResult Edit(int id)
        {
            var abonament = _context.Membership.Find(id);
            if (abonament == null)
            {
                return NotFound();
            }
            ViewBag.GymList = GetAllGyms();
            return View(abonament);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Membership abonament)
        {
            if (id != abonament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var abonamentDinBaza = _context.Membership.Find(id);
                if (abonamentDinBaza != null)
                {
                    abonamentDinBaza.Titlu = abonament.Titlu;
                    abonamentDinBaza.Valoare = abonament.Valoare;
                    abonamentDinBaza.GymId = abonament.GymId;
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.GymList = GetAllGyms();
            return View(abonament);
        }
        public IActionResult Delete(int id)
        {
            var abonament = _context.Membership.Include(a => a.Gym).FirstOrDefault(a => a.Id == id);
            if (abonament == null)
            {
                return NotFound();
            }
            return View(abonament);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var abonament = _context.Membership.Find(id);
            if (abonament != null)
            {
                _context.Membership.Remove(abonament);
                _context.SaveChanges();
            }
            TempData["Message"] = "Abonamentul a fost sters cu succes!";
            return RedirectToAction("Index");
        }
        private IEnumerable<SelectListItem> GetAllGyms()
        {
            return _context.Gym.Select(sala => new SelectListItem
            {
                Value = sala.Id.ToString(),
                Text = sala.Nume
            }).ToList();
        }
    }
}
