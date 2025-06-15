using SAE2._01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAE2._01
{


        public class Stub
        {

            public List<Personnage> persoInit = new();
            public List<Objet> objetsInit = new();
            private List<User> usersInit = new();
            public List<Competences> competencesInit = new();

            public List<User> UsersInit { get => usersInit; set => usersInit = value; }
        ///<summary>
        /// Propriété publique permettant d'accéder à la liste des utilisateurs (usersInit).
        /// Cette propriété est utilisée pour obtenir ou définir la valeur de la liste depuis l'extérieur de la classe.
        /// </summary>


        public void GestionPersonnage(List<Personnage> personnages)
            {

        }
        //private static Task Load()
     //   {
            //Ronly.AddRange(new Personnage[] {

            //new Personnage(200, "aatrox", "aatrox1.jpg","top.png", "mid.png"),
            //new Personnage(150, "ahri", "ahri1.jpg", "top.png", "mid.png"),
            //new Personnage(160, "akali", "akali1.jpg", "top.png", "mid.png"),
            //new Personnage(70, "akshan", "akshan1.jpg", "top.png", "mid.png"),
            //new Personnage (300, "alistar", "alistar1.jpg", "support.png", "top.png"),
            //new Personnage(50, "amumu", "amumu1.jpg", "top.png", "mid.png"),
            //new Personnage(350, "anivia", "anivia1.jpg", "top.png", "mid.png"),
            //new Personnage(60, "annie", "annie.jpg", "top.png", "mid.png"),
            //new Personnage(210, "kayle", "kayle.jpg", "top.png", "mid.png"),
            //new Personnage(175, "ryze", "ryze.jpg", "top.png", "mid.png"),
            //new Personnage(170, "yi", "yi.jpg", "top.png", "mid.png")
   //     }

            public void GestionObjet()
            {
                Objet obj1 = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
                {
                    Penetration_armure = 1,
                    Armure = 1,
                    Dégât = 1,
                    Armure_magique = 11,
                    Puissance = 1,
                    Vitesse_attaque = 1,
                    Pourcentage_coup_critique = 1,
                    Penetration_magique = 1,
                    Passif = "aa"

                };
                objetsInit.Add(obj1);

            }

            public void GestionCompetence()
            {
                Competences comp1 = new Competences(TypeCompetence.Passif, "gros cou", "fait mal");
                competencesInit.Add(comp1);
            }


            public void GestionUtilisateur()
            {
                User user1 = new User("Bob", "Marley", 123, "bob@marley.com");
                UsersInit.Add(user1);
            }

            public List<Personnage> GetPersonnages()
            {
                return persoInit;
            }

            public List<Objet> GetObjets()
            {
                return objetsInit;
            }

            public List<Competences> GetCompetences()
            {
                return competencesInit;
            }
            public List<User> GetUtilisateur()
            {
                return UsersInit;
            }



        }
    }

