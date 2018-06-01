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
    public class EvenementController : Controller
    {
        // GET: Evenement
        public ActionResult Index()
        {
            List<EvenementViewModel> listes = new List<EvenementViewModel>();


            List<Evenement> evenements = ServiceEvenement.GetAll();
            foreach (Evenement ev in evenements)
            {
                listes.Add(new EvenementViewModel(ev));
            }

            return View(listes);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(Guid id)
        {
            EvenementViewModel EVM = new EvenementViewModel(ServiceEvenement.GetAll().FirstOrDefault(e => e.ID == id));
            return View(EVM);
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(Guid? id)
        {
            return View(EvenementViewModel.Get(id));
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(EvenementViewModel EVM)
        {
            try
            {
                EVM.Save();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return View();
            }
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
