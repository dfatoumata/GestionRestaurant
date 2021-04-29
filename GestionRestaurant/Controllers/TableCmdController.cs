using AutoMapper;
using GestionRestaurant.Models;
using GestionRestaurant.Repositories.Interfaces;
using GestionRestaurant.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Controllers
{
    public class TableCmdController : Controller
    {
        private readonly ITableCmdRepository _TableCmdRepository;
        private readonly IServeurRepository _ServeurRepository;
        private readonly IMapper _mapper;
        public TableCmdController(ITableCmdRepository TableCmdRepository, IServeurRepository ServeurRepository, IMapper mapper)
        {
            _TableCmdRepository = TableCmdRepository;
            _ServeurRepository = ServeurRepository;
            _mapper = mapper;
        }
        // GET: TableCmdController
        public ActionResult Index()
        {
            var tableCmds = _TableCmdRepository.GetAllWithServeurs();
            var tableOccupees = tableCmds.Where(tbl => tbl.Occupation == true).Count();
            ViewData["tableOccupees"] = tableOccupees;
            ViewBag.tableocc = tableOccupees;

            var tableLibres = tableCmds.Where(tbl => tbl.Occupation == false).Count();
            ViewData["tableLibres"] = tableLibres;

            return View(tableCmds);
        }

        // GET: TableCmdController/Details/5
        public ActionResult Details(int id)
        {
            var TableCmd = _TableCmdRepository.GetByIdWithServer(id);

           var tableCmd= _mapper.Map<DetailsTableCmdViewModel>(TableCmd);
            return View(tableCmd);
        }

        // GET: TableCmdController/Create
        public ActionResult Create()
        {
            TableCmdViewModel tableCmdViewModel = new TableCmdViewModel();

            tableCmdViewModel.Serveurs = _ServeurRepository.GetAll().Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Name }).ToList();
            return View(tableCmdViewModel);
        }

        // POST: TableCmdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TableCmdViewModel TableCmdViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                //TableCmd tableCmd = new TableCmd();
                //tableCmd.ID = TableCmdViewModel.ID;
                //tableCmd.Number = TableCmdViewModel.Number;
                //tableCmd.NumberOfPlace = TableCmdViewModel.NumberOfPlace;
                //tableCmd.Occupation = TableCmdViewModel.Occupation;
                //tableCmd.Place = TableCmdViewModel.Place;
                //tableCmd.ServeurId = TableCmdViewModel.ServeurId;
                var tableCmd = _mapper.Map<TableCmd>(TableCmdViewModel);
                _TableCmdRepository.Add(tableCmd);
                _TableCmdRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TableCmdController/Edit/5
        public ActionResult Edit(int id)
        {
            var TableCmd = _TableCmdRepository.GetByID(id);
            var tableCmdViewModel = _mapper.Map<TableCmdViewModel>(TableCmd);
            tableCmdViewModel.Serveurs = _ServeurRepository.GetAll().Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Name }).ToList();
            return View(tableCmdViewModel);
        }

        // POST: TableCmdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TableCmdViewModel TableCmd)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _TableCmdRepository.GetByID(id);
            if (exist == null)
            {
                return NotFound();
            }
            try
            {
                var tableCmd = _mapper.Map<TableCmd>(TableCmd);
                _TableCmdRepository.Update(tableCmd);
                _TableCmdRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TableCmdController/Delete/5
        public ActionResult Delete(int id)
        {
            var TableCmd = _TableCmdRepository.GetByID(id);
            return View(TableCmd);
        }

        // POST: TableCmdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TableCmd TableCmd)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _TableCmdRepository.GetByID(id);
            if (exist == null)
            {
                return NotFound();
            }
            try
            {
                _TableCmdRepository.DeleteByID(id);
                _TableCmdRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
