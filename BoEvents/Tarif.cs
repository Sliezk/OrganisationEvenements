using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEvents
{
    public class Tarif
    {
        public Guid ID { get; set; }
        public String DebutPeriode { get; set; }
        public Boolean Jour { get; set; }
        public double Montant { get; set; }
        public double Coeff { get; set; }
        public int DureeMax { get; set; }

        public Tarif() {
            this.ID = Guid.NewGuid();
        }

        public Tarif(String debutPeriode, Boolean jour, double montant, double coeff, int dureeMax) {
            this.ID = Guid.NewGuid();
            this.DebutPeriode = debutPeriode;
            this.Jour = jour;
            this.Montant = montant;
            this.Coeff = coeff;
            this.DureeMax = dureeMax;
        }

    }
}
