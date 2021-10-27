using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

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
        public async Task<IActionResult> Index()
        {
            var list = await _vendeurService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departements = await _departementService.FindAllAsync();
            var viewModel = new VendeurFormViewModel { Departements = departements };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendeur vendeur)
        {
            if (!ModelState.IsValid)
            {
                var departements = _departementService.FindAllAsync();
                var viewModel = new VendeurFormViewModel { Vendeur = vendeur, Departements = (ICollection<Departement>)departements }; //Cast test
                return View(viewModel);
            }
             await _vendeurService.InsertAsync(vendeur);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _vendeurService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendeurService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _vendeurService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _vendeurService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Departement> departements = await _departementService.FindAllAsync();
            VendeurFormViewModel viewModel = new VendeurFormViewModel {Vendeur = obj, Departements = departements };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Edit(int id, Vendeur vendeur)
        {
            if (!ModelState.IsValid)
            {
                var departements = await _departementService.FindAllAsync();
                var viewModel = new VendeurFormViewModel { Vendeur = vendeur, Departements = departements };
                return View(viewModel);
            }
            if (id != vendeur.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _vendeurService.UpdateAsync(vendeur);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(String message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
        


    }
}
