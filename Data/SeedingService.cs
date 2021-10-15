using System;
using System.Linq;
using SalesWebMvc.Models;
using SalesWevMvc.Models;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesMvcContext _context;

        public SeedingService()
        {

        }

        public SeedingService(SalesMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departement.Any() ||
                _context.Vendeur.Any() ||
                _context.EnregistrementVentes.Any())
            {
                return; //DB has been seedes
            }

            Departement d1 = new Departement(1, "Computers");
            Departement d2 = new Departement(2, "Computers");
            Departement d3 = new Departement(3, "Computers");
            Departement d4 = new Departement(4, "Computers");
        }
    }
}
