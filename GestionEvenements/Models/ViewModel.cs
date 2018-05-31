using BoEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionEvenements.Models
{
    public class ViewModel<T> where T : IEntityIdentifiable
    {
        public T Metier { get; protected set; }

        public Guid ID
        {
            get
            { return this.Metier.ID; }
            set
            { this.Metier.ID = value; }
        }

    }
}