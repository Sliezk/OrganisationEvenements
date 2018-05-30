namespace GestionEvenements
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using BoEvents;
    using DalEvents;
    using GestionEvenements;

    public class Dal : IDal
    {

        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Evenement> GetListEvents()
        {
            return bdd.Evenements.ToList();
        }

        public void CreerEvenement(string lieu, DateTime date, int duree, string theme)
        {
            bdd.Evenements.Add(new Evenement { Lieu = lieu, Date = date, Duree = duree, Theme = theme });
            bdd.SaveChanges();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

    }
}