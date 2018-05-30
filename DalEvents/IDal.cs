using BoEvents;
using System;
using System.Collections.Generic;

namespace GestionEvenements
{
    public interface IDal : IDisposable
    {

        List<Evenement> GetListEvents();
        void CreerEvenement(string lieu, DateTime date, int duree, string theme);

    }
}
