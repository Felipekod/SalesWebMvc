using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

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

        public async Task<List<Vendeur>> FindAllAsync()
        {
            return await _context
                .Vendeur
                .Include(e => e.Departament)
                .ToListAsync();
        }

        public async Task InsertAsync(Vendeur obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendeur> FindByIdAsync(int id)
        {
            return await _context
                .Vendeur
                .Include(e => e.Departament)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Vendeur.FindAsync(id);
                _context.Vendeur.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
            
        }

        public async Task UpdateAsync(Vendeur obj)
        {
            bool hasAny = await _context.Vendeur.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
