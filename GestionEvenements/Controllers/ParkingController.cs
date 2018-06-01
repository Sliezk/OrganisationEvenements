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

        // GET: Parking
        public ActionResult ListerParkings()
        {
            //ViewBag.Tarif = ;
            //ViewBag.Cout = ;
            return View(ParkingViewModel.GetAll());
        }

        public ActionResult DetailsEvenement(Guid ID)
        {

            return View(ServiceEvenement.Get(ID));
        }

        public ActionResult Map()
        {
            return View();
        }
    }
}