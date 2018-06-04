using BoEvents;
using DalEvents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceTheme
    {
        public static List<Theme> GetAll()
        {
            List<Theme> retour = null;
            using (BddContext context = new BddContext())
            {
                retour = context.Themes.ToList();

            }
            return retour;
        }

        public static Theme Get(Guid id)
        {
            Theme retour = null;
            using (BddContext context = new BddContext())
            {
                retour = context.Themes.FirstOrDefault(t => t.ID == id);

            }
            return retour;
        }

        private static Theme Get(Guid id, BddContext context)
        {
            return context.Themes.FirstOrDefault(t => t.ID == id);
        }

        public static void Insert(Theme t)
        {
            using (BddContext context = new BddContext())
            {
                context.Themes.Add(t);
                context.SaveChanges();
            }
        }

        public static void Update(Theme t)
        {
            using (BddContext context = new BddContext())
            {
                EntityState s = context.Entry(t).State;
                Theme tExistant = Get(t.ID, context);
                tExistant.Nom = t.Nom;

                context.SaveChanges();
            }
        }
    }
}
