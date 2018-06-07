using BoEvents;
using DalEvents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                retour = context.Evenements.Include("Theme").Include("Image").ToList();

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
                retour = context.Evenements.FirstOrDefault(e => e.ID == id);

            }
            return retour;
        }

        //surcharge, on la met en private car utilisée uniquement par le service
        private static Evenement Get(Guid id, BddContext context)
        {
            return context.Evenements.FirstOrDefault(e => e.ID == id);
        }

        public static void Insert(Evenement e)
        {
            using (BddContext context = new BddContext())
            {
                
                e.Theme = ServiceTheme.Get(e.Theme.ID, context);
                //e.
                //e.Image.Add
                //e.Image = ServiceImage.Get(e.Image.ID, context);

                context.Evenements.Add(e);
                context.SaveChanges();
            }
        }
        
        public static void Update(Evenement e)
        {
            using (BddContext context = new BddContext())
            {
                EntityState s = context.Entry(e).State;
                Evenement eExistant = Get(e.ID, context);
                eExistant.Nom = e.Nom;
                eExistant.Lieu = e.Lieu;
                eExistant.Duree = e.Duree;
                Theme tExistant = ServiceTheme.Get(e.Theme.ID, context);
                eExistant.Theme = tExistant;
                eExistant.Date = e.Date;
                eExistant.Description = e.Description;
               // eExistant.Image = e.Image;

                context.SaveChanges();
            }
        }
    }
}
