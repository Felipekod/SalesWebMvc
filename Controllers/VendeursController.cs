using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesWebMvc.Controllers
{
    public class VendeursController : Controller
    {
        private readonly VendeurService _vendeurService;
        private readonly DepartementService _departementService;

        public VendeursController(VendeurService vendeurService, DepartementService departementService)
        {
            _vendeurService = vendeurService;
            _departementService = departementService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _vendeurService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departements = _departementService.FindAll();
            var viewModel = new VendeurFormViewModel { Departements = departements };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendeur vendeur)
        {
            _vendeurService.Insert(vendeur);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _vendeurService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendeurService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendeurService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


    }
}
