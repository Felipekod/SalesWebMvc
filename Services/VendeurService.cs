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

        public void Insert(Vendeur obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendeur FindById(int id)
        {
            return _context
                .Vendeur
                .Include(e => e.Departament)
                .FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendeur.Find(id);
            _context.Vendeur.Remove(obj);
            _context.SaveChanges();
        }
    }
}
