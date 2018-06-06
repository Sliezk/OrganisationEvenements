using System;
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

        public Evenement(Guid id, string nom, string lieu, DateTime date, int duree, Theme theme, string description, Image image) : this()
        {
            ID = id;
            Nom = nom;
            Lieu = lieu;
            Date = date;
            Duree = duree;
            Theme = theme;
            Description = description;
            Image = image;
        }

        public Guid ID { get; set; }

        public string Nom { get; set; }

        public string Lieu { get; set; }

        public DateTime Date { get; set; }

        public int Duree { get; set; }

        public Theme Theme { get; set; }

        public Guid ThemeID { get; set; }

        public string Description { get; set; }

        public Image Image { get; set; }

    }
}