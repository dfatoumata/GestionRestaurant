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
    public class ServeursController : Controller
    {
        private readonly IServeurRepository _serveurrepository;
        public ServeursController(IServeurRepository serveurrepository)
        {
            _serveurrepository = serveurrepository;
        }
        // GET: ServeursController
        public ActionResult Index()
        {
            var serveurs = _serveurrepository.GetAll();
            return View(serveurs);
        }

        // GET: ServeursController/Details/5
        public ActionResult Details(int id)
        {
            var serveur = _serveurrepository.GetByID(id);
            return View(serveur);
        }

        // GET: ServeursController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServeursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Serveur serveur)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _serveurrepository.Add(serveur);
                _serveurrepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServeursController/Edit/5
        public ActionResult Edit(int id)
        {
            var serveur = _serveurrepository.GetByID(id);
            return View(serveur);
        }

        // POST: ServeursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Serveur serveur)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _serveurrepository.GetByID(id);
            if (exist==null)
            {
                return NotFound();
            }
            try
            {
                _serveurrepository.Update(serveur);
                _serveurrepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ServeursController/Delete/5
        public ActionResult Delete(int id)
        {
            var serveur = _serveurrepository.GetByID(id);
            return View(serveur);
        }

        // POST: ServeursController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Serveur serveur)
        {
            try
            {
                _serveurrepository.DeleteByID(id);
                _serveurrepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
