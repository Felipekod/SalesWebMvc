using System;
namespace SalesWebMvc.Models
{
    public class EnregistrementVentes
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public double Valeur { get; set; }
        public StatusVente Status { get; set; }
        public Vendeur Vendeur { get; set; }

        public EnregistrementVentes()
        {
        }

        public EnregistrementVentes(int id, DateTime date, double valeur, StatusVente status, Vendeur vendeur)
        {
            this.Id = id;
            this.Date = date;
            this.Valeur = valeur;
            this.Status = status;
            this.Vendeur = vendeur;
        }
    }
}
