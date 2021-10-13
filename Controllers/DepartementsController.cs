using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesWebMvc.Controllers
{
    public class DepartementsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Departement> liste = new List<Departement>();
            liste.Add(new Departement { Id= 1, Nom = "Eletroniques" });
            liste.Add(new Departement { Id = 2, Nom = "Mode" });


            return View(liste);
        }
    }
}
