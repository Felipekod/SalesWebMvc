using System;
using SalesWebMvc.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Departement>> FindAllAsync()
        {
            return await _context
                .Departement
                .OrderBy(x => x.Nom)
                .ToListAsync();
        }
    }
}
