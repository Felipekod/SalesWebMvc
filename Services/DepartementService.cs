using System;
using SalesWebMvc.Models;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMvc.Services
{
    public class DepartementService
    {
        private readonly SalesMvcContext _context;

        public DepartementService()
        {
        }

        public DepartementService(SalesMvcContext context)
        {
            _context = context;
        }

        public List<Departement> FindAll()
        {
            return _context.Departement.OrderBy(x => x.Nom).ToList();
        }
    }
}
