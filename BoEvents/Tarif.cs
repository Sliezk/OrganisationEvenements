using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEvents
{
    class Tarif
    {
        public Guid ID { get; set; }

        public Boolean PremiereHeure { get; set; }

        public Boolean Premieres24h { get; set; }

        public Boolean AuDelaDe7j { get; set; }

        public float Montant { get; set; }

        public Tarif() {
            this.ID = Guid.NewGuid();
        }

        public Tarif(Boolean premiereHeure, Boolean premieres24h, Boolean auDelaDe7j, float montant) {
            this.ID = Guid.NewGuid();
            this.PremiereHeure = premiereHeure;
            this.Premieres24h = premieres24h;
            this.AuDelaDe7j = auDelaDe7j;
            this.Montant = montant;
        }

    }
}
