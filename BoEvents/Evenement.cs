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
            this.ID = Guid.NewGuid();
        }

        public Evenement(string lieu, DateTime date, int duree, string theme) : this()
        {
            this.ID = Guid.NewGuid();
            this.Lieu = lieu;
            this.Date = date;
            this.Duree = duree;
            this.Theme = theme;
        }

        public Evenement(Guid id, string lieu, DateTime date, int duree, string theme, string image) : this()
        {
            this.ID = Guid.NewGuid();
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