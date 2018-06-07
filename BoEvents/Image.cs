using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEvents
{
    public class Image : IEntityIdentifiable
    {

        public Image()
        {

        }

        public Image(Guid id, string path, string fichier)
        {
            ID = id;
            Path = path;
            Fichier = fichier;
        }

        public Guid ID { get; set; }
        public string Path { get; set; }
        public string Fichier { get; set; }

    }
}
