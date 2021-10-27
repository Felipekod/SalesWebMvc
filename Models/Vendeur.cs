using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Vendeur
    {
        public int Id { get; set; }
        public string NomComplet { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        [Display(Name = "Salaire heure")]
        [DisplayFormat(DataFormatString = "{0:f2}")]
        public double SalaireBase { get; set; }
        public Departement Departament { get; set; }
        public int DepartementId { get; set; }
        public ICollection<EnregistrementVentes> ventes { get; set; } = new List<EnregistrementVentes>();

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
            ventes.Add(ev);
        }

        public void removeVente(EnregistrementVentes ev)
        {
            ventes.Remove(ev);
        }

        public double ventesTotale(DateTime debut, DateTime fin)
        {
            return ventes.Where(ev => ev.Date >= debut && ev.Date <= fin).Sum(ev => ev.Valeur);
        }
    }
}
