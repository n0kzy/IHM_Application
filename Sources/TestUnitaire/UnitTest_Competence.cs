using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE2._01;
using System;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest_Competence
    {
        [TestMethod]
        public void TestNom()
        {
            Competences c = new Competences(TypeCompetence.Passif, "gros cou", "fait mal");

            Assert.AreEqual("gros cou", c.Nom);
        }

        [TestMethod]
        public void TestDescription()
        {
            Competences c = new Competences(TypeCompetence.Passif, "gros cou", "fait mal");

            Assert.AreEqual("fait mal", c.Description);
        }

        [TestMethod]
        public void TestType()
        {
            Competences c = new Competences(TypeCompetence.Passif, "gros cou", "fait mal");

            Assert.AreEqual(TypeCompetence.Passif, c.Type);
        }
    }
}