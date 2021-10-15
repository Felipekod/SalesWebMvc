using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWevMvc.Models
{
    public class SalesMvcContext : DbContext
    {
        public SalesMvcContext (DbContextOptions<SalesMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departement> Departement { get; set; }
        public DbSet<Vendeur> Vendeur { get; set; }
        public DbSet<EnregistrementVentes> EnregistrementVentes { get; set; }
    }
}