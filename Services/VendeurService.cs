using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class VendeurService
    {
        private readonly SalesMvcContext _context;

        public VendeurService()
        {
        }

        public VendeurService(SalesMvcContext context)
        {
            _context = context;
        }

        public List<Vendeur> FindAll()
        {
            return _context
                .Vendeur
                .Include(e => e.Departament)
                .ToList();
        }
    }
}
