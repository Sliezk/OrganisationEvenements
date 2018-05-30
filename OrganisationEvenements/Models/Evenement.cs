using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganisationEvenements.Models
{
    public class Evenement
    {

        public Evenement()
        {
        }

        public Evenement(Guid id, string lieu, DateTime date, int duree, string theme) : this()
        {
            this.ID = id;
            this.Lieu = lieu;
            this.Date = date;
            this.Duree = duree;
            this.Theme = theme;
        }

        public Evenement(Guid id, string lieu, DateTime date, int duree, string theme, string image) : this()
        {
            this.ID = id;
            this.Lieu = lieu;
            this.Date = date;
            this.Duree = duree;
            this.Theme = theme;
            this.Image = image;
        }

        public Guid ID { get; set; }

        public string Lieu { get; set; }

        public DateTime Date { get; set; }

        public int Duree { get; set; }

        public string Theme { get; set; }

        public string Image { get; set; }

    }
}