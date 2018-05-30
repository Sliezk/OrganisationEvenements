using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrganisationEvenements.Models;

namespace OrganisationEvenements
{
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

        public void Dispose()
        {
            bdd.Dispose();
        }

    }
}