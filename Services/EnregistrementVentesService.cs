using System;
using System.Collections.Generic;
using SalesWebMvc.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class EnregistrementVentesService 
    {

        private readonly SalesMvcContext _context;

        public EnregistrementVentesService(SalesMvcContext context)
        {
            _context = context;
        }

        public async Task<List<EnregistrementVentes>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.EnregistrementVentes select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                        .Include(x => x.Vendeur)
                        .Include(x => x.Vendeur.Departament)
                        .OrderByDescending(x => x.Date)
                        .ToListAsync();
        }

        public async Task<List<IGrouping<Departement, EnregistrementVentes>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.EnregistrementVentes select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            var data = await result
                        .Include(x => x.Vendeur)
                        .Include(x => x.Vendeur.Departament)
                        .OrderByDescending(x => x.Date)
                        .ToListAsync();

            return data.GroupBy(x => x.Vendeur.Departament).ToList();
        }
    }
}
