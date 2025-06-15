using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE2._01;
using System.Collections.Generic;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest_Personnage
    {
        [TestMethod]
        public void TestInitialisation()
        {
            Dictionary<string, Competences> dic = new Dictionary<string, Competences>();
            dic.Add("comp1", new Competences(TypeCompetence.Classique, "nom1", "description1"));
            dic.Add("comp2", new Competences(TypeCompetence.Classique, "nom2", "description2"));
            dic.Add("comp3", new Competences(TypeCompetence.Classique, "nom3", "description3"));
            dic.Add("comp4", new Competences(TypeCompetence.Classique, "nom4", "description4"));
            dic.Add("comp5", new Competences(TypeCompetence.Classique, "nom5", "description5"));

            Personnage p = new Personnage(20, "anni", "urlimage", "role1", "role2", "histoire", dic);

            Assert.IsNotNull(p);
            Assert.AreEqual(20, p.Poids);
            Assert.AreEqual("anni", p.Name);
            Assert.AreEqual("urlimage", p.ImageUrl);
            Assert.AreEqual("histoire", p.Histoire);
            Assert.AreEqual("role1", p.Role1);
            Assert.AreEqual("role2", p.Role2);

            Assert.AreEqual(TypeCompetence.Classique, p.dic["comp1"].Type);
            Assert.AreEqual("nom1", p.dic["comp1"].Nom);
            Assert.AreEqual("description1", p.dic["comp1"].Description);

            Assert.AreEqual(TypeCompetence.Classique, p.dic["comp2"].Type);
            Assert.AreEqual("nom2", p.dic["comp2"].Nom);
            Assert.AreEqual("description2", p.dic["comp2"].Description);

            Assert.AreEqual(TypeCompetence.Classique, p.dic["comp3"].Type);
            Assert.AreEqual("nom3", p.dic["comp3"].Nom);
            Assert.AreEqual("description3", p.dic["comp3"].Description);

            Assert.AreEqual(TypeCompetence.Classique, p.dic["comp4"].Type);
            Assert.AreEqual("nom4", p.dic["comp4"].Nom);
            Assert.AreEqual("description4", p.dic["comp4"].Description);

            Assert.AreEqual(TypeCompetence.Classique, p.dic["comp5"].Type);
            Assert.AreEqual("nom5", p.dic["comp5"].Nom);
            Assert.AreEqual("description5", p.dic["comp5"].Description);

        }

        [TestMethod]
        [DataRow(50)]
        public void TestPersonnageWeight(int weight)
        {
            Dictionary<string, Competences> dic = new Dictionary<string, Competences>();
            Personnage p = new Personnage(weight, "john", "imageurl", "story", "role1", "role2", dic);

            Assert.AreEqual(weight, p.Poids);
        }

        [TestMethod]
        [DataRow("jane")]
        public void TestPersonnageName(string name)
        {
            Dictionary<string, Competences> dic = new Dictionary<string, Competences>();
            Personnage p = new Personnage(30, name, "imageurl", "story", "role1", "role2", dic);

            Assert.AreEqual(name, p.Name);
        }

        [TestMethod]
        [DataRow("imageurl")]
        public void TestPersonnageImageUrl(string imageUrl)
        {
            Dictionary<string, Competences> dic = new Dictionary<string, Competences>();
            Personnage p = new Personnage(40, "alex", imageUrl, "story", "role1", "role2", dic);

            Assert.AreEqual(imageUrl, p.ImageUrl);
        }
    }
}