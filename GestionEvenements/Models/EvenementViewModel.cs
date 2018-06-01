using BoEvents;
using System;
using System.Collections.Generic;
using Service;

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

        public string Theme
        {
            get {return this.Metier.Theme;}
            set {Metier.Theme = value;}
        }


        public void Save()
        {
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



        /// <summary>
        /// retourne un livre ViewModel
        /// </summary>
        /// <param name="id">Identifiant nullable du livre</param>
        /// <returns>si id null, retourne un viewModel avec un livre initialisé; Si id a une valeur retourne le viewModel avec le livre en BDD
        /// </returns>
        public static EvenementViewModel Get(Guid? id)
        {
            EvenementViewModel retour = null;

            if (id.HasValue)
            {
                retour = new EvenementViewModel(ServiceEvenement.Get(id.Value));
            }
            else
            {
                Evenement e = new Evenement() { ID = Guid.Empty, Nom = "Default", Lieu = "Default", Theme = "Default" };
                retour = new EvenementViewModel(e);
            }

            return retour;
        }
    }
}