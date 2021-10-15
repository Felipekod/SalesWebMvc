using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Vendeur
    {
        public int Id { get; set; }
        public string NomComplet { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }
        public double SalaireBase { get; set; }
        public Departement Departament { get; set; }
        public ICollection<EnregistrementVentes> Ventes { get; set; } = new List<EnregistrementVentes>();

        public Vendeur()
        {
        }

        public Vendeur(int id, string nomComplet, string email, DateTime dateNaissance, double salaireBase, Departement departament)
        {
            this.Id = id;
            this.NomComplet = nomComplet;
            this.Email = email;
            this.DateNaissance = dateNaissance;
            this.SalaireBase = salaireBase;
            this.Departament = departament;
        }

        public void addVentes(EnregistrementVentes ev)
        {
            Ventes.Add(ev);
        }

        public void removeVente(EnregistrementVentes ev)
        {
            Ventes.Remove(ev);
        }

        public double ventesTotale(DateTime debut, DateTime fin)
        {
            return Ventes.Where(ev => ev.Date >= debut && ev.Date <= fin).Sum(ev => ev.Valeur);
        }
    }
}
