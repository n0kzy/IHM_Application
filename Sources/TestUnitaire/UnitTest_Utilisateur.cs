using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE2._01;
using System;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest_Utilisateur
    {
        [TestMethod]
        public void TestPrenom()
        {
            User a = new User("Pat", "Bru", 123, "pat@uca");

            Assert.AreEqual("Pat", a.Prenom);
        }

        [TestMethod]
        public void TestNom()
        {
            User a = new User("Pat", "Bru", 123, "pat@uca");

            Assert.AreEqual("Bru", a.Nom);
        }

        [TestMethod]
        public void TestMotDePasse()
        {
            User a = new User("Pat", "Bru", 123, "pat@uca");

            Assert.AreEqual(123, a.Mot_de_passe);
        }

        [TestMethod]
        public void TestEmail()
        {
            User a = new User("Pat", "Bru", 123, "pat@uca");

            Assert.AreEqual("pat@uca", a.Email);
        }
    }
}