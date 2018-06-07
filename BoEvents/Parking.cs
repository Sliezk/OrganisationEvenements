using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEvents
{
    public class Parking : IEntityIdentifiable
    {
        public Guid ID { get; set; }

        public String Lieu { get; set; }

        public String Nom { get; set; }

        public String Statut { get; set; }

        public int NbPlacesLibres { get; set; }

        public int Capacite { get; set; }

        public int SeuilComplet { get; set; }

        public List<Tarif> Tarifs { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public Parking() {
            this.ID = Guid.NewGuid();
        }

        public Parking(String lieu, String nom, int capacite, int seuilComplet, List<Tarif> tarifs) {
            this.ID = Guid.NewGuid();
            this.Lieu = lieu;
            this.Nom = nom;
            this.Capacite = capacite;
            this.SeuilComplet = seuilComplet;
            this.Tarifs = tarifs;
        }

    }
}
