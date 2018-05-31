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


        public string Lieu
        {
            get
            {
                return this.Metier.Lieu;
            }
            set
            {
                this.Metier.Lieu = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.Metier.Date;
            }
            set
            {
                this.Metier.Date = value;
            }
        }

        public int Duree
        {
            get
            {
                return this.Metier.Duree;
            }
            set
            {
                this.Metier.Duree = value;
            }
        }

        public string Theme
        {
            get
            {
                return this.Metier.Theme;
            }
            set
            {
                this.Metier.Theme = value;
            }
        }


        public void Save()
        {
            if (this.ID == Guid.Empty)
            {
                //insert
                ServiceEvenement.Insert(this.Metier);
            }
            else
            {
                //update
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
                Evenement l = new Evenement() { ID = Guid.Empty, Lieu = "Default" };
                retour = new EvenementViewModel(l);
            }

            return retour;
        }
    }
}