﻿using BoEvents;
using System;
using System.Collections.Generic;
using Service;
using GestionEvenements.Controllers;

namespace GestionEvenements.Models
{
    public class EvenementViewModel : ViewModel<Evenement>
    {
        public EvenementViewModel()
        {
            this.Metier = new Evenement();
        }
        public EvenementViewModel(Evenement e)
        {
            this.Metier = e;

        }

        public string Nom
        {
            get {return this.Metier.Nom;}
            set {Metier.Nom = value;}
        }

        public string Lieu
        {
            get {return this.Metier.Lieu;}
            set {Metier.Lieu = value;}
        }

        public DateTime Date
        {
            get {return this.Metier.Date;}
            set {Metier.Date = value;}
        }

        public int Duree
        {
            get {return this.Metier.Duree;}
            set {Metier.Duree = value;}
        }

        public Theme Theme
        {
            get { return this.Metier.Theme; }
            set { Metier.Theme = value; }
        }

        public Guid ThemeID
        {
            get { return this.Metier.ThemeID; }
            set { Metier.ThemeID = value; }
        }

        public string Description
        {
            get { return this.Metier.Description; }
            set { Metier.Description = value; }
        }

        public List<Image> Image
        {
            get { return this.Metier.Image; }
            set { Metier.Image = value; }
        }


        public void Save(List<ImageViewModel> listeImg)
        {
            if (this.Metier.Theme == null)
            {
                this.Metier.Theme = new Theme() { ID = this.ThemeID, Nom = ServiceTheme.Get(this.ThemeID).Nom };
            }

            if (this.Metier.Image == null)
            {
                this.Metier.Image = new List<Image>();
                foreach (ImageViewModel IVM in listeImg)
                {
                    Image img = new Image() { ID = IVM.ID, Fichier = IVM.Fichier, Path = IVM.Path };
                    this.Metier.Image.Add(img);
                }
            }

            if (this.ID == Guid.Empty)
            {
                //insert
                this.ID = Guid.NewGuid();
                ServiceEvenement.Insert(this.Metier);
            }
            else
            {
                //update
                ServiceEvenement.Update(this.Metier);
            }
        }

        public void Delete(EvenementViewModel EVM)
        {
            ServiceEvenement.Remove(EVM.Metier);
        }

        public static List<EvenementViewModel> GetAll()
        {
            List<EvenementViewModel> retour = new List<EvenementViewModel>();


            List<Evenement> evenements = ServiceEvenement.GetAll();
            foreach (Evenement e in evenements)
            {
                retour.Add(new EvenementViewModel(e));
            }

            return retour;
        }

        public static EvenementViewModel Get(Guid? id)
        {
            EvenementViewModel retour = null;

            if (id.HasValue)
            {
                retour = new EvenementViewModel(ServiceEvenement.Get(id.Value));
            }
            else
            {
                Evenement e = new Evenement() { ID = Guid.Empty, Nom = "Default", Lieu = "Default", Date = DateTime.Now };
                retour = new EvenementViewModel(e);
            }

            return retour;
        }
    }
}