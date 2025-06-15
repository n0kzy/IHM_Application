using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace SAE2._01
{
    public class Objet
    {
        public int PV ;
        public int Dégât { get; init; }
        public int Puissance { get; init; }
        public int Armure { get; init; }
        public int Armure_magique { get; init; }
        public int Penetration_armure { get; init; }
        public int Penetration_magique { get; init; }
        public int Vitesse_attaque { get; init; }
        public int Pourcentage_coup_critique { get; init; }
        public string Passif;

        public Objet(int degat, int puissance, int armure, int armure_magique,int penetration_armure,int penetration_magique,int vitesse_attaque,int pourcentage_critique,string passif)
        {
            this.Passif = passif;
            this.Puissance = puissance; 
            this.Armure = armure;
            this.Dégât = armure_magique;
            this.Armure_magique = armure_magique;
            this.Penetration_armure = penetration_armure;
            this.Penetration_magique = penetration_magique;
            this.Vitesse_attaque = vitesse_attaque;
            this.Pourcentage_coup_critique = pourcentage_critique;
        }


    }

}




