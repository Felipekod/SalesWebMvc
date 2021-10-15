using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Departement
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Vendeur> Vendeurs { get; set; } = new List<Vendeur>();

        public Departement()
        {
        }

        public Departement(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public void addVendeur(Vendeur vendeur)
        {
            Vendeurs.Add(vendeur);
        }

        public double ventesTotale(DateTime debut, DateTime fin){
            return Vendeurs.Sum(vendeur => vendeur.ventesTotale(debut, fin));
        }

    }
}
