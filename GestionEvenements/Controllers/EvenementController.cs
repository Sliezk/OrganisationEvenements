using BoEvents;
using GestionEvenements.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            
            List<Evenement> evenements = ServiceEvenement.GetAll();
            foreach (Evenement ev in evenements)
            {
                listes.Add(new EvenementViewModel(ev));
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
            List<ImageViewModel> images = new List<ImageViewModel>();

            try
            {
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Image img = new Image();
                        var fileI = Request.Files[i];
                        if (fileI != null && fileI.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(fileI.FileName);
                            string code = Guid.NewGuid().ToString();
                            string fileName2 = code + "" + fileName;
                            var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName2);
                            var pathBdd = "~/Content/Images/" + fileName2;
                            if (!System.IO.File.Exists(path))
                            {
                                fileI.SaveAs(path);
                                img.ID = Guid.NewGuid();
                                img.Fichier = fileName;
                                img.Path = pathBdd;
                                images.Add(new ImageViewModel(img));
                            }
                        }
                    }
                }
                EVM.Save(images);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(EvenementViewModel.Get(id));
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(EvenementViewModel EVM)
        {
            try
            {
                if (EVM == null)
                {
                    return HttpNotFound();
                }
                EVM.Delete(EVM);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
