using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionEvenements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoEvents;

namespace GestionEvenements
{
    [TestClass]
    public class DalTests
    {
        [TestMethod]
        public void CreerEvenement_AvecUnNouvelEvenement_ObtientTousLesEvenementsRenvoieBienLEvenement()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerEvenement("Lieu random", new DateTime(2018, 06, 11, 12, 00, 00), 2, "Thème random");
                List<Evenement> evenements = dal.GetListEvents();

                Assert.IsNotNull(evenements);
                Assert.AreEqual(1, evenements.Count);
                Assert.AreEqual("Lieu random", evenements[0].Lieu);
                Assert.AreEqual("Thème random", evenements[0].Theme);
            }
        }

        public void CreerUtilisateur_AvecUnNouvelUtilisateur_ObtientTousLesUtilisateursRenvoieBienLUtilisateur()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerEvenement("Lieu random", new DateTime(2018, 06, 11, 12, 00, 00), 2, "Thème random");
                List<Evenement> evenements = dal.GetListEvents();

                Assert.IsNotNull(evenements);
                Assert.AreEqual(1, evenements.Count);
                Assert.AreEqual("Lieu random", evenements[0].Lieu);
                Assert.AreEqual("Thème random", evenements[0].Theme);
            }
        }

    }
}