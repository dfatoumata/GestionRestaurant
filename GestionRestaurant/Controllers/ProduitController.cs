using GestionRestaurant.Models;
using GestionRestaurant.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitRepository _produitRepository;
        public ProduitController(IProduitRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }
        // GET: ProduitController
        public ActionResult Index()
        {
            _produitRepository.GetAll();
            return View();
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            var produit = _produitRepository.GetByID(id);
            return View(produit);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _produitRepository.Add(produit);
                _produitRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
           var produit= _produitRepository.GetByID(id);
            return View(produit);
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _produitRepository.GetByID(id);
            if (exist== null)
            {
                return NotFound();
            }
            try
            {
                _produitRepository.Update(produit);
                _produitRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            var produit = _produitRepository.GetByID(id);
            return View(produit);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _produitRepository.GetByID(id);
            if (exist == null)
            {
                return NotFound();
            }
            try
            {
                _produitRepository.DeleteByID(id);
                _produitRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
