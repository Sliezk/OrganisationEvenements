﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoEvents
{
    public class Evenement : IEntityIdentifiable
    {

        public Evenement()
        {

        }

        public Evenement(Guid id, string nom, string lieu, DateTime date, int duree, Theme theme, string description) : this()
        {
            ID = id;
            Nom = nom;
            Lieu = lieu;
            Date = date;
            Duree = duree;
            Theme = theme;
            Description = description;
        }

        public Guid ID { get; set; }

        public string Nom { get; set; }

        public string Lieu { get; set; }

        public DateTime Date { get; set; }

        public int Duree { get; set; }

        public Theme Theme { get; set; }        

        public string Description { get; set; }

    }
}