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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<EvenementViewModel> listes = new List<EvenementViewModel>();
            List<Theme> listeThemes = new List<Theme>();


            List<Evenement> evenements = ServiceEvenement.GetAll();
            foreach (Evenement ev in evenements)
            {
                listes.Add(new EvenementViewModel(ev));
            }

            List<Theme> themes = ServiceTheme.GetAll();
            foreach (Theme th in themes)
            {
                listeThemes.Add(th);
            }

            return View(listes);
        }

        // GET: Evenement/ListerThemes
        public ActionResult ListerThemes()
        {
            List<Theme> listeThemes = new List<Theme>();
            
            List<Theme> themes = ServiceTheme.GetAll();
            foreach (Theme th in themes)
            {
                listeThemes.Add(th);
            }

            return View(listeThemes);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(Guid id)
        {
            EvenementViewModel EVM = new EvenementViewModel(ServiceEvenement.GetAll().FirstOrDefault(e => e.ID == id));
            Theme theme = ServiceTheme.Get(EVM.Theme.ID);
            ViewBag.Theme = theme;
            return View(EVM);
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(Guid? id)
        {
            List<Theme> listeThemes = new List<Theme>();
            foreach (Theme th in ServiceTheme.GetAll())
            {
                listeThemes.Add(th);
            }
            ViewBag.ListeThemes = listeThemes;
            return View(EvenementViewModel.Get(id));
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(EvenementViewModel EVM)
        {
            try
            {
                // file1 to store image in binary formate and file2 to store path and url  
                // we are checking file1 and file2 are null or not according to that different case are there  
                /*if (File1 != null && File1.ContentLength > 0 && File2 != null)
                {
                    EVM.Image = new byte[File1.ContentLength]; // file1 to store image in binary formate  
                    File1.InputStream.Read(EVM.Image, 0, File1.ContentLength);
                    string ImageName = System.IO.Path.GetFileName(File2.FileName); //file2 to store path and url  
                    string physicalPath = Server.MapPath("~/img/" + ImageName);
                    // save image in folder  
                    File2.SaveAs(physicalPath);
                // store path in database  
                    EVM.ImagePath = "img/" + ImageName;
                    EVM.Save();
                }
                if (File1 != null && File1.ContentLength > 0 && File2 == null)
                {
                    EVM.Image = new byte[File1.ContentLength]; // file1 to store image in binary formate  
                    File1.InputStream.Read(EVM.Image, 0, File1.ContentLength);
                    EVM.Save();
                }
                if (File1 == null && File2 != null)
                {
                    string ImageName = System.IO.Path.GetFileName(File2.FileName); //file2 to store path and url  
                    string physicalPath = Server.MapPath("~/img/" + ImageName);
                    // save image in folder  
                    File2.SaveAs(physicalPath);
                    EVM.ImagePath = "img/" + ImageName;
                    EVM.Save();
                }






                if (File2 != null)
                {
                    string ImageName = System.IO.Path.GetFileName(File2.FileName); //file2 to store path and url  
                    string physicalPath = Server.MapPath("~/img/" + ImageName);
                    File2.SaveAs(physicalPath);
                    EVM.ImagePath = "img/" + ImageName;
                    EVM.Save();
                }
                if (File2 == null)
                {
                    EVM.Save();
                }
                else
                { 
                    EVM.Save();
                }*/
                EVM.Save();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
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
