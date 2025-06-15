using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE2._01;
using System;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest_Objet
    {
        [TestMethod]
        [DataRow(1)]
        public void TestPenetrationArmure(int penetrationArmure)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Penetration_armure = penetrationArmure
            };

            Assert.AreEqual(penetrationArmure, o.Penetration_armure);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestArmure(int armure)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Armure = armure
            };

            Assert.AreEqual(armure, o.Armure);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestDegat(int degat)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Dégât = degat
            };

            Assert.AreEqual(degat, o.Dégât);
        }

        [TestMethod]
        [DataRow(11)]
        public void TestArmureMagique(int armureMagique)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Armure_magique = armureMagique
            };

            Assert.AreEqual(armureMagique, o.Armure_magique);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestPuissance(int puissance)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Puissance = puissance
            };

            Assert.AreEqual(puissance, o.Puissance);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestVitesseAttaque(int vitesseAttaque)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Vitesse_attaque = vitesseAttaque
            };

            Assert.AreEqual(vitesseAttaque, o.Vitesse_attaque);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestPourcentageCoupCritique(int pourcentageCoupCritique)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Pourcentage_coup_critique = pourcentageCoupCritique
            };

            Assert.AreEqual(pourcentageCoupCritique, o.Pourcentage_coup_critique);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestPenetrationMagique(int penetrationMagique)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Penetration_magique = penetrationMagique
            };

            Assert.AreEqual(penetrationMagique, o.Penetration_magique);
        }

        [TestMethod]
        [DataRow("aa")]
        public void TestPassif(string passif)
        {
            Objet o = new Objet(1, 1, 1, 11, 1, 1, 1, 1, "aa")
            {
                Passif = passif
            };

            Assert.AreEqual(passif, o.Passif);
        }
    }
}