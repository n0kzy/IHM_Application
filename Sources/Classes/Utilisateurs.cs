using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE2._01
{
    public class User
    {
        public string Prenom { get; private set; }
        public string Nom { get; private set; }
        public int Mot_de_passe { get; private set; }
        public string Email { get; private set; }
        

        public User(string Prenom, string Nom, int mot_de_passe, string Email) {
            this.Prenom = Prenom;
            this.Nom = Nom;
            this.Mot_de_passe = mot_de_passe;
            this.Email = Email;
                }

    }
}
