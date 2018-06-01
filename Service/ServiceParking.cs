using BoEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceParking
    {
        public static List<Parking> GetAll()
        {
            List<Parking> retour = null;

            //retour = WebServiceParking.Lister;

            return retour;
        }

        public static Parking Get(Guid id)
        {
            Parking retour = null;

            List<Parking> parkings = GetAll();
            retour = parkings.Find(x => x.ID.ToString().Contains(id.ToString()));

            return retour;
        }

    }
}
