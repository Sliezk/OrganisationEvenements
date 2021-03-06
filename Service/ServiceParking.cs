﻿using BoEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceParking
    {
        public static List<Parking> GetAll()
        {
            List<Parking> retour = new List<Parking>();
            JsonListeParkings parkings = new JsonListeParkings();
            parkings = WebServiceParking.getJsonResponse<JsonListeParkings>("http://data.citedia.com/r1/parks", parkings);

            foreach (Park p in parkings.parks)
            {
                Parking parking = new Parking();
                parking.Nom = p.parkInformation.name;
                parking.Statut = p.parkInformation.status;
                parking.Capacite = p.parkInformation.max;
                parking.NbPlacesLibres = p.parkInformation.free;
                retour.Add(parking);
            }

            foreach (Feature f in parkings.features.features)
            {
                switch (f.id){
                    case "dinan-chezy":
                        retour.Find(x => x.Nom.ToString().Contains("Chézy-Dinan")).Longitude = f.geometry.coordinates[1];
                        retour.Find(x => x.Nom.ToString().Contains("Chézy-Dinan")).Latitude = f.geometry.coordinates[0];
                        break;
                    case "charles-de-gaulle":
                        retour.Find(x => x.Nom.ToString().Contains("Charles de Gaulle")).Longitude = f.geometry.coordinates[1];
                        retour.Find(x => x.Nom.ToString().Contains("Charles de Gaulle")).Latitude = f.geometry.coordinates[0];
                        break;
                    case "kleber":
                        retour.Find(x => x.Nom.ToString().Contains("Kléber")).Longitude = f.geometry.coordinates[1];
                        retour.Find(x => x.Nom.ToString().Contains("Kléber")).Latitude = f.geometry.coordinates[0];
                        break;
                    default:
                        retour.Find(x => x.Nom.ToString().Normalize().ToLower().Contains(f.id)).Longitude = f.geometry.coordinates[1];
                        retour.Find(x => x.Nom.ToString().Normalize().ToLower().Contains(f.id)).Latitude = f.geometry.coordinates[0];
                        break;
                }            
            }

            List<CsvTarifs> records = WebServiceParking.getTarifs("http://data.citedia.com/r1/parks/timetable-and-prices");
            foreach (CsvTarifs record in records) {
                //Récupération du tarif
                List<Tarif> tarifs = new List<Tarif>();
                if (record.Parking == "colombier" || record.Parking == "lices" || record.Parking == "hoche") {
                    for (int i = 0; i < 4; i++)
                    {
                        Tarif tarif = null;
                        switch (i)
                        {
                            case 0:
                                tarif = new Tarif("0", true, double.Parse(record.Tarifs.Substring(34, 4)),0.25,1);
                                break;
                            case 1:
                                tarif = new Tarif("1", true, double.Parse(record.Tarifs.Substring(65, 4)),0.25,13);
                                break;
                            case 2:
                                tarif = new Tarif("-1", false, double.Parse(record.Tarifs.Substring(113, 4)),0.25,10);
                                break;
                            case 3:
                                tarif = new Tarif("24", true, double.Parse(record.Tarifs.Substring(147, 4)),4,-1);
                                break;
                        }
                        tarifs.Add(tarif);
                    }
                }
                if (record.Parking == "charles-de-gaulle")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Tarif tarif = null;
                        switch (i)
                        {
                            case 0:
                                tarif = new Tarif("0", true, double.Parse(record.Tarifs.Substring(34, 4)), 0.25,1);
                                break;
                            case 1:
                                tarif = new Tarif("1", true, double.Parse(record.Tarifs.Substring(65, 4)), 0.25,13);
                                break;
                            case 2:
                                tarif = new Tarif("-1", false, double.Parse(record.Tarifs.Substring(113, 4)), 0.25,10);
                                break;
                            case 3:
                                tarif = new Tarif("24", true, double.Parse(record.Tarifs.Substring(147, 4)), 0.5, 144);
                                break;
                            case 4:
                                tarif = new Tarif("168", true, double.Parse(record.Tarifs.Substring(180, 4)), 1,-1);
                                break;
                        }
                        tarifs.Add(tarif);
                    }
                }
                if (record.Parking == "arsenal" || record.Parking == "dinan-chezy" || record.Parking == "kleber" || record.Parking == "vilaine")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Tarif tarif = null;
                        switch (i)
                        {
                            case 0:
                                tarif = new Tarif("0", true, double.Parse(record.Tarifs.Substring(34, 4)), 0.25,14);
                                break;
                            case 1:
                                tarif = new Tarif("-1", false, double.Parse(record.Tarifs.Substring(67, 4)), 0.25,10);
                                break;
                            case 2:
                                if (record.Parking == "vilaine")
                                {
                                    tarif = new Tarif("24", true, double.Parse(record.Tarifs.Substring(101, 4)), 0.25,-1);
                                }
                                else {
                                    tarif = new Tarif("24", true, double.Parse(record.Tarifs.Substring(101, 4)), 4,-1);
                                }
                                break;
                        }
                        tarifs.Add(tarif);
                    }
                } 
                if (record.Parking == "gare-sud")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Tarif tarif = null;
                        switch (i)
                        {
                            case 0:
                                tarif = new Tarif("0", true, double.Parse(record.Tarifs.Substring(34, 4)), 0.25,2);
                                break;
                            case 1:
                                tarif = new Tarif("2", true, double.Parse(record.Tarifs.Substring(65, 4)), 0.25,2);
                                break;
                            case 2:
                                tarif = new Tarif("4", true, double.Parse(record.Tarifs.Substring(96, 4)), 0.25,10);
                                break;
                            case 3:
                                tarif = new Tarif("-1", false, double.Parse(record.Tarifs.Substring(145, 4)), 0.25,10);
                                break;
                            case 4:
                                tarif = new Tarif("24", true, double.Parse(record.Tarifs.Substring(179, 4)), 0.5,-1);
                                break;
                        }
                        tarifs.Add(tarif);
                    }
                }

                //Inclusion dans la liste
                switch (record.Parking)
                {
                    case "dinan-chezy":
                        retour.Find(x => x.Nom.ToString().Contains("Chézy-Dinan")).Lieu = record.Adresse;
                        retour.Find(x => x.Nom.ToString().Contains("Chézy-Dinan")).SeuilComplet = Int32.Parse(record.Seuil_complet);
                        retour.Find(x => x.Nom.ToString().Contains("Chézy-Dinan")).Tarifs = tarifs;
                        break;
                    case "charles-de-gaulle":
                        retour.Find(x => x.Nom.ToString().Contains("Charles de Gaulle")).Lieu = record.Adresse;
                        retour.Find(x => x.Nom.ToString().Contains("Charles de Gaulle")).SeuilComplet = Int32.Parse(record.Seuil_complet);
                        retour.Find(x => x.Nom.ToString().Contains("Charles de Gaulle")).Tarifs = tarifs;
                        break;
                    case "kleber":
                        retour.Find(x => x.Nom.ToString().Contains("Kléber")).Lieu = record.Adresse;
                        retour.Find(x => x.Nom.ToString().Contains("Kléber")).SeuilComplet = Int32.Parse(record.Seuil_complet);
                        retour.Find(x => x.Nom.ToString().Contains("Kléber")).Tarifs = tarifs;
                        break;
                    default:
                        retour.Find(x => x.Nom.ToString().Normalize().ToLower().Contains(record.Parking)).Lieu = record.Adresse;
                        retour.Find(x => x.Nom.ToString().Normalize().ToLower().Contains(record.Parking)).SeuilComplet = Int32.Parse(record.Seuil_complet);
                        retour.Find(x => x.Nom.ToString().Normalize().ToLower().Contains(record.Parking)).Tarifs = tarifs;
                        break;
                }
            }

            //Ajout de l'addresse du parking gratuit centre commercial Kennedy
            retour.Find(x => x.Nom.ToString().Contains("Centre Commercial Kennedy")).Lieu = "50 cours Du President Jf Kennedy";

            return retour;
        }

        public static Parking Get(Guid id)
        {
            Parking retour = null;

            List<Parking> parkings = GetAll();
            retour = parkings.Find(x => x.ID.ToString().Contains(id.ToString()));

            return retour;
        }

        public static List<Parking> GetNearests(Evenement e)
        {
            List<Parking> retour = new List<Parking>();
            Dictionary<String, double> distances = new Dictionary<String, double>();

            GoogleGeocoder geo = new GoogleGeocoder();
            Coordinates c1 = geo.Geocode(e.Lieu + " Rennes");

            List<Parking> parkings = GetAll();

            foreach (Parking p in parkings) {
                Coordinates c2 = geo.Geocode(p.Lieu + " Rennes");
                p.Longitude = c2.Longitude;
                p.Latitude = c2.Latitude;
                double distance = Distance.distance(c1.Latitude, c1.Longitude, c2.Latitude, c2.Longitude,'K');
                distances.Add(p.Nom, distance);
            }

            List<KeyValuePair<string, double>> myList = distances.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            for (int i = 0; i < 3; i++) {
                retour.Add(parkings.Find(x => x.Nom.ToString().Contains(myList[i].Key)));
            }

            return retour;
        }

        public static double GetCost(Evenement e, Parking p) {
            double retour = 0;
            float duree = e.Duree;
            float dureeRestante = e.Duree;
            DateTime horaire = e.Date;
            Tarif tarif;

            if (p.Nom == "Colombier" || p.Nom == "Les Lices" || p.Nom == "Hoche")
            {
                if (e.Duree < 24)
                {
                    if (horaire.Hour > 9 && (horaire.Hour + duree) < 21)
                    {
                        if (duree < 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * duree / tarif.Coeff;
                        }
                        if (duree > 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                            retour += tarif.Montant * (duree - 1) / tarif.Coeff;
                        }
                    }
                    if (horaire.Hour > 21 && (horaire.Hour + duree) < 31)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * duree / tarif.Coeff;
                    }
                    if (horaire.Hour < 9 && (horaire.Hour + duree) < 21)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * (9 - horaire.Hour) / tarif.Coeff;
                        dureeRestante -= 9 - horaire.Hour;
                        if (dureeRestante < 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * dureeRestante / tarif.Coeff;
                        }
                        if (dureeRestante > 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                            retour += tarif.Montant * (dureeRestante - 1) / tarif.Coeff;
                        }
                    }
                    if (horaire.Hour < 21 && (horaire.Hour + duree) < 31)
                    {
                        if (dureeRestante < 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * (21 - horaire.Hour) / tarif.Coeff;
                        }
                        if (dureeRestante > 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                            retour += tarif.Montant * ((21 - horaire.Hour) - 1) / tarif.Coeff;
                        }
                        dureeRestante -= 21 - horaire.Hour;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * dureeRestante / tarif.Coeff;

                    }
                }
                else
                {
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                    retour += tarif.Montant / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                    retour += tarif.Montant * 13 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                    retour += tarif.Montant * 10 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("24"));
                    retour += tarif.Montant * (duree-24) / tarif.Coeff;
                }
            }

            if (p.Nom == "Charles de Gaulle")
            {
                if (e.Duree < 24)
                {
                    if (horaire.Hour > 9 && (horaire.Hour + duree) < 21)
                    {
                        if (duree < 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * duree / tarif.Coeff;
                        }
                        if (duree > 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                            retour += tarif.Montant * (duree - 1) / tarif.Coeff;
                        }
                    }
                    if (horaire.Hour > 21 && (horaire.Hour + duree) < 31)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * duree / tarif.Coeff;
                    }
                    if (horaire.Hour < 9 && (horaire.Hour + duree) < 21)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * (9 - horaire.Hour) / tarif.Coeff;
                        dureeRestante -= 9 - horaire.Hour;
                        if (dureeRestante < 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * dureeRestante / tarif.Coeff;
                        }
                        if (dureeRestante > 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                            retour += tarif.Montant * (dureeRestante - 1) / tarif.Coeff;
                        }
                    }
                    if (horaire.Hour < 21 && (horaire.Hour + duree) < 31)
                    {
                        if (dureeRestante < 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * (21 - horaire.Hour) / tarif.Coeff;
                        }
                        if (dureeRestante > 1)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                            retour += tarif.Montant * ((21 - horaire.Hour) - 1) / tarif.Coeff;
                        }
                        dureeRestante -= 21 - horaire.Hour;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * dureeRestante / tarif.Coeff;

                    }
                }
                else
                {
                    if (e.Duree < 168)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                        retour += tarif.Montant / tarif.Coeff;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                        retour += tarif.Montant * 13 / tarif.Coeff;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * 10 / tarif.Coeff;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("24"));
                        retour += tarif.Montant * (duree-24) / tarif.Coeff;
                    }
                    else {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                        retour += tarif.Montant / tarif.Coeff;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("1"));
                        retour += tarif.Montant * 13 / tarif.Coeff;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * 10 / tarif.Coeff;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("24"));
                        retour += tarif.Montant * 120 / tarif.Coeff;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("24"));
                        retour += tarif.Montant * (duree-144) / tarif.Coeff;
                    }
                        
                }
            }

            if (p.Nom == "Arsenal" || p.Nom == "Chézy-Dinan" || p.Nom == "Kléber" || p.Nom == "Vilaine")
            {
                if (e.Duree < 24)
                {
                    if (horaire.Hour > 9 && (horaire.Hour + duree) < 21)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                        retour += tarif.Montant * duree / tarif.Coeff;
                    }
                    if (horaire.Hour > 21 && (horaire.Hour + duree) < 31)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * duree / tarif.Coeff;
                    }
                    if (horaire.Hour < 9 && (horaire.Hour + duree) < 21)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * (9 - horaire.Hour) / tarif.Coeff;
                        dureeRestante -= 9 - horaire.Hour;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                        retour += tarif.Montant * dureeRestante / tarif.Coeff;
                    }
                    if (horaire.Hour < 21 && (horaire.Hour + duree) < 31)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                        retour += tarif.Montant * (21 - horaire.Hour) / tarif.Coeff;
                        dureeRestante -= 21 - horaire.Hour;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * dureeRestante / tarif.Coeff;

                    }
                }
                else
                {
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                    retour += tarif.Montant *14 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                    retour += tarif.Montant * 10 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("24"));
                    retour += tarif.Montant * (duree - 24) / tarif.Coeff;
                }
            }

            if (p.Nom == "Gare-Sud") {
                if (e.Duree < 24)
                {
                    if (horaire.Hour > 9 && (horaire.Hour + duree) < 21)
                    {
                        if (duree < 2)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * duree / tarif.Coeff;
                        }
                        if (duree > 2 && duree<=4)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("2"));
                            retour += tarif.Montant * (duree - 2) / tarif.Coeff;
                        }
                        if (duree > 4)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("2"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("4"));
                            retour += tarif.Montant * (duree - 2) / tarif.Coeff;
                        }
                    }
                    if (horaire.Hour > 21 && (horaire.Hour + duree) < 31)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * duree / tarif.Coeff;
                    }
                    if (horaire.Hour < 9 && (horaire.Hour + duree) < 21)
                    {
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * (9 - horaire.Hour) / tarif.Coeff;
                        dureeRestante -= 9 - horaire.Hour;
                        if (dureeRestante < 2)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * dureeRestante / tarif.Coeff;
                        }
                        if (dureeRestante > 2 && dureeRestante < 4)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("2"));
                            retour += tarif.Montant * (dureeRestante - 2) / tarif.Coeff;
                        }
                        if (dureeRestante > 4)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("2"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("4"));
                            retour += tarif.Montant * (dureeRestante - 2) / tarif.Coeff;
                        }
                    }
                    if (horaire.Hour < 21 && (horaire.Hour + duree) < 31 && (horaire.Hour + duree) >21)
                    {
                        if (duree < 2)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * (21 - horaire.Hour) / tarif.Coeff;
                        }
                        if (duree > 2 && duree < 4)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("2"));
                            retour += tarif.Montant * ((21 - horaire.Hour) - 2) / tarif.Coeff;
                        }
                        if (duree > 4)
                        {
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("2"));
                            retour += tarif.Montant * 2 / tarif.Coeff;
                            tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("4"));
                            retour += tarif.Montant * ((21 - horaire.Hour) - 2) / tarif.Coeff;
                        }
                        dureeRestante -= 21 - horaire.Hour;
                        tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                        retour += tarif.Montant * dureeRestante / tarif.Coeff;

                    }
                }
                else
                {
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("0"));
                    retour += tarif.Montant * 2 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("2"));
                    retour += tarif.Montant * 2 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("4"));
                    retour += tarif.Montant * 10 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("-1"));
                    retour += tarif.Montant * 10 / tarif.Coeff;
                    tarif = p.Tarifs.Find(x => x.DebutPeriode.ToString().Contains("24"));
                    retour += tarif.Montant * (duree - 24) / tarif.Coeff;
                }
            }

            return retour;
        }

    }
}
