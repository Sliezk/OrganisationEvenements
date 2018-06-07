using BoEvents;
using DalEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public static class ServiceImage
    {
        public static List<Image> GetAll()
        {
            List<Image> retour = null;
            using (BddContext context = new BddContext())
            {
                retour = context.Images.ToList();
            }
            return retour;
        }
        
        public static Image Get(Guid id)
        {
            Image retour = null;
            using (BddContext context = new BddContext())
            {
                retour = context.Images.FirstOrDefault(i => i.ID == id);

            }
            return retour;
        }

        public static Image Get(Guid id, BddContext context)
        {
            return context.Images.FirstOrDefault(i => i.ID == id);
        }

        public static void Insert(Image i)
        {
            using (BddContext context = new BddContext())
            {
                context.Images.Add(i);
                context.SaveChanges();
            }
        }
    }
}