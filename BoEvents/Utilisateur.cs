using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEvents
{
    public class Utilisateur
    {

        public Utilisateur()
        {
        }

        public Utilisateur(Guid id, string nom, string prenom, string email, string adresse, string role) : this()
        {
            this.ID = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
            this.Adresse = adresse;
            this.Role = role;
        }

        public Guid ID { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public string Adresse { get; set; }

        public string Role { get; set; }

    }
}
