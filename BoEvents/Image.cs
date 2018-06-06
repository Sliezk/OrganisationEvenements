using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEvents
{
    public class Image
    {

        public Image()
        {

        }

        public Image(Guid id, byte[] codeBinaire)
        {
            ID = id;
            CodeBinaire = codeBinaire;
        }

        public Guid ID { get; set; }
        public byte[] CodeBinaire { get; set; }

    }
}
