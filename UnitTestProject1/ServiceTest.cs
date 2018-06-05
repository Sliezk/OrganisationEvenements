using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void RecupererListeParks()
        {
            JsonListeParkings parkings = new JsonListeParkings();
            parkings = WebServiceParking.getJsonResponse<JsonListeParkings>("http://data.citedia.com/r1/parks", parkings);

            Assert.IsNotNull(parkings);
        }

        [TestMethod]
        public void GetAllParkings()
        {

            Assert.IsNotNull(ServiceParking.GetAll());
        }

        [TestMethod]
        public void GetTarifs()
        {
            Assert.IsNotNull(WebServiceParking.getTarifs("http://data.citedia.com/r1/parks/timetable-and-prices"));
        }

        [TestMethod]
        public void GetNearest()
        {
            BoEvents.Evenement e = new BoEvents.Evenement();
            e.Lieu = "Rennes";
            e.Nom = "j'aime la viande";
            Assert.IsNotNull(ServiceParking.GetNearests(e));
        }

    }
}
