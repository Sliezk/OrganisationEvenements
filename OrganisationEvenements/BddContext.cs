using OrganisationEvenements.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrganisationEvenements
{
    public class BddContext : DbContext
    {

        public DbSet<Evenement> Evenements { get; set; }
    }
}