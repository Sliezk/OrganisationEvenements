using OrganisationEvenements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationEvenements
{
    public interface IDal : IDisposable
    {

        List<Evenement> GetListEvents();

    }
}
