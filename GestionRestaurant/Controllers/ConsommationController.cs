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
    public class ConsommationController : Controller
    {
        private readonly IConsommationRepository _ConsommationRepository;
        public ConsommationController(IConsommationRepository ConsommationRepository)
        {
            _ConsommationRepository = ConsommationRepository;
        }
        // GET: ConsommationController
        public ActionResult Index()
        {
            _ConsommationRepository.GetAll();
            return View();
        }

        // GET: ConsommationController/Details/5
        public ActionResult Details(int id)
        {
            var Consommation = _ConsommationRepository.GetByID(id);
            return View(Consommation);
        }

        // GET: ConsommationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsommationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consommation Consommation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ConsommationRepository.Add(Consommation);
                _ConsommationRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConsommationController/Edit/5
        public ActionResult Edit(int id)
        {
            var Consommation = _ConsommationRepository.GetByID(id);
            return View(Consommation);
        }

        // POST: ConsommationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Consommation Consommation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _ConsommationRepository.GetByID(id);
            if (exist == null)
            {
                return NotFound();
            }
            try
            {
                _ConsommationRepository.Update(Consommation);
                _ConsommationRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConsommationController/Delete/5
        public ActionResult Delete(int id)
        {
            var Consommation = _ConsommationRepository.GetByID(id);
            return View(Consommation);
        }

        // POST: ConsommationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Consommation Consommation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _ConsommationRepository.GetByID(id);
            if (exist == null)
            {
                return NotFound();
            }
            try
            {
                _ConsommationRepository.DeleteByID(id);
                _ConsommationRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
