using BoEvents;
using GestionEvenements.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionEvenements.Controllers
{
    public class ParkingController : Controller
    {
        public ActionResult ListerEvenements()
        {
            return View(EvenementViewModel.GetAll());
        }

        public ActionResult Description(Guid ID)
        {
            ViewBag.ID = ID;
            return View();
        }

        // GET: Parking
        public ActionResult ListerParkings(Guid ID)
        {
            Evenement e = ServiceEvenement.Get(ID);
            //ViewBag.Tarif = ;
      
            return View(ParkingViewModel.GetNearest(e));
        }

        public ActionResult DetailsEvenement(Guid ID)
        {

            return View(EvenementViewModel.Get(ID));
        }

        public ActionResult Map()
        {
            return View();
        }
    }
}