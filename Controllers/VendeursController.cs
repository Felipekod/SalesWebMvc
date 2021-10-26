using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesWebMvc.Controllers
{
    public class VendeursController : Controller
    {
        private readonly VendeurService _vendeurService;

        public VendeursController(VendeurService vendeurService)
        {
            _vendeurService = vendeurService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _vendeurService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendeur vendeur)
        {
            _vendeurService.Insert(vendeur);
            return RedirectToAction(nameof(Index));
        }
    }
}
