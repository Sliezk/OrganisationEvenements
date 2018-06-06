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

        public Image(Guid id, string path)
        {
            ID = id;
            Path = path;
        }

        public Guid ID { get; set; }
        public string Path { get; set; }

    }
}
