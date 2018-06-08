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

        public ActionResult Description(Guid ID, String nom)
        {
            ViewBag.ID = ID;
            ViewBag.Nom = nom;
            return View();
        }

        // GET: Parking
        public ActionResult ListerParkings(Guid ID)
        {
            Evenement e = ServiceEvenement.Get(ID);
            //ViewBag.Tarif = ;
      
            return PartialView(ParkingViewModel.GetNearest(e));
        }

        public ActionResult DetailsEvenement(Guid ID)
        {

            return PartialView(EvenementViewModel.GetAll().FirstOrDefault(e => e.ID == ID));
        }

        public ActionResult Map(Guid ID)
        {
            Evenement e = ServiceEvenement.Get(ID);
            List<Parking> p = ServiceParking.GetNearests(e);
            ViewBag.Adresse = e.Lieu;
            for (int i = 0; i < 3; i++) {
                String lg = p[i].Longitude.ToString().Replace(",", ".");
                String lat = p[i].Latitude.ToString().Replace(",", ".");

                ViewData.Add("long"+i, lg);
                ViewData.Add("lat" + i, lat);
                ViewData.Add("nom" + i, p[i].Nom.ToString().Replace("é", "e"));
            }
            return PartialView();
        }
    }
}