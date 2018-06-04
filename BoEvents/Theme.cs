using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEvents
{
    public class Theme : IEntityIdentifiable
    {

        public Theme ()
        {
        }

        public Theme(Guid id, string nom) : this()
        {
            ID = id;
            Nom = nom;
        }

        public Guid ID { get; set; }

        public string Nom { get; set; }
    }
}
