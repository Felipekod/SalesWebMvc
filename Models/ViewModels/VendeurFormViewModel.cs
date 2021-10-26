using System;
using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class VendeurFormViewModel
    {
        public Vendeur Vendeur { get; set; }
        public ICollection<Departement> Departements { get; set; }

        public VendeurFormViewModel()
        {
        }
    }
}
