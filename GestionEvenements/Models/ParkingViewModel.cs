using System;
using BoEvents;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service;

namespace GestionEvenements.Models
{
    public class ParkingViewModel : ViewModel<Parking>
    {

        public ParkingViewModel()
        {
            this.Metier = new Parking();
        }
        public ParkingViewModel(Parking p)
        {
            this.Metier = p;

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

        public string Nom
        {
            get
            {
                return this.Metier.Nom;
            }
            set
            {
                this.Metier.Nom = value;
            }
        }

        public string Statut
        {
            get
            {
                return this.Metier.Statut;
            }
            set
            {
                this.Metier.Statut = value;
            }
        }

        public int NbPlacesLibres
        {
            get
            {
                return this.Metier.NbPlacesLibres;
            }
            set
            {
                this.Metier.NbPlacesLibres = value;
            }
        }

        public int Capacite
        {
            get
            {
                return this.Metier.Capacite;
            }
            set
            {
                this.Metier.Capacite = value;
            }
        }

        public int SeuilComplet
        {
            get
            {
                return this.Metier.SeuilComplet;
            }
            set
            {
                this.Metier.SeuilComplet = value;
            }
        }

        public List<Tarif> Tarifs
        {
            get
            {
                return this.Metier.Tarifs;
            }
            set
            {
                this.Metier.Tarifs = value;
            }
        }

        public double Cout { get; set; }

        public static List<ParkingViewModel> GetAll()
        {
            List<ParkingViewModel> retour = new List<ParkingViewModel>();


            List<Parking> parkings = ServiceParking.GetAll();
            foreach (Parking p in parkings)
            {
                retour.Add(new ParkingViewModel(p));
            }

            return retour;
        }


        public static ParkingViewModel Get(Guid? id)
        {
            ParkingViewModel retour = null;

            if (id.HasValue)
            {
                retour = new ParkingViewModel(ServiceParking.Get(id.Value));
            }
            else
            {
                Parking p = new Parking() { ID = Guid.Empty, Lieu = "Default" };
                retour = new ParkingViewModel(p);
            }

            return retour;
        }

        public static List<ParkingViewModel> GetNearest(Evenement e)
        {
            List<ParkingViewModel> retour = new List<ParkingViewModel>();


            List<Parking> parkings = ServiceParking.GetNearests(e);
            foreach (Parking p in parkings)
            {
                ParkingViewModel pvm = new ParkingViewModel(p);
                pvm.Cout = ServiceParking.GetCost(e, p);
                retour.Add(pvm);
            }

            return retour;
        }

    }
}