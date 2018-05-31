using BoEvents;
using DalEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public static class ServiceEvenement
    {
        /// <summary>
        /// liste des événements présents en BDD
        /// </summary>
        /// <returns>liste des événements</returns>
        public static List<Evenement> GetAll()
        {
            List<Evenement> retour = null;
            using (BddContext context = new BddContext())
            {
                retour = context.Evenements.ToList();

            }
            return retour;
        }

        /// <summary>
        /// retoune le livre en BDD
        /// </summary>
        /// <param name="id">identifiant du livre</param>
        /// <returns></returns>
        public static Evenement Get(Guid id)
        {
            Evenement retour = null;
            using (BddContext context = new BddContext())
            {
                retour = context.Evenements.FirstOrDefault(l => l.ID == id);

            }
            return retour;
        }

        public static void Insert(Evenement e)
        {
            using (BddContext context = new BddContext())
            {
                context.Evenements.Add(e);
                context.SaveChanges();
            }
        }

        /* TODO
        public static void Update(Evenement e)
        {
            using (BddContext context = new BddContext())
            {
                EntityState s = context.Entry(e).State;
                Evenement lExistant = context.Livres.FirstOrDefault();
                lExistant.Titre = l.Titre;
                lExistant.Resume = l.Resume;
                lExistant.NBPages = l.NBPages;
                lExistant.Prix = l.Prix;

                context.SaveChanges();
            }
        }*/
    }
}
