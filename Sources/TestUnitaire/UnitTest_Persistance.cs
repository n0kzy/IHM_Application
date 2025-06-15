using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace SAE2._01.TestUnitaire
{
    [TestClass]
    public class PersistanceTests
    {
        private string testDirectory;
        private string testFile;

        [TestMethod]
        public void testPersistance()
        {
            Persistance persistance = new Persistance(Environment.CurrentDirectory, "personnages.xml");

        }
        [TestMethod]
        public void TestAddAllPerso()
        {
            Persistance persistance = new Persistance(Environment.CurrentDirectory, "personnages.xml");
            persistance.addAllPerso();
            
           Dictionary<string, Competences> dicAatrox = persistance.personnages[0].dic;
            Assert.IsNotNull(dicAatrox);
            Assert.IsTrue(dicAatrox.ContainsKey("comp1"));
            Assert.IsTrue(dicAatrox.ContainsKey("comp2"));
            Assert.IsTrue(dicAatrox.ContainsKey("comp3"));
            Assert.IsTrue(dicAatrox.ContainsKey("comp4"));
            Assert.IsTrue(dicAatrox.ContainsKey("comp5"));

            Competences comp1Aatrox = dicAatrox["comp1"];
            Assert.AreEqual(TypeCompetence.Passif, comp1Aatrox.Type);
            Assert.AreEqual("Posture du massacreur", comp1Aatrox.Nom);
            Assert.AreEqual("Régulièrement, la prochaine attaque de base d'Aatrox inflige des dégâts physiques supplémentaires et le soigne, selon un pourcentage des PV max de la cible.", comp1Aatrox.Description);
            Competences comp2Aatrox = dicAatrox["comp2"];
            Assert.AreEqual(TypeCompetence.Classique, comp2Aatrox.Type);
            Assert.AreEqual("Épée des Darkin", comp2Aatrox.Nom);
            Assert.AreEqual("Aatrox abat son épée devant lui, infligeant des dégâts physiques. Il peut frapper jusqu'à 3 fois et chaque coup a une zone d'effet différente.", comp2Aatrox.Description);

            
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Créer une instance de Persistance avec le chemin d'accès au répertoire courant et le nom du fichier XML
            Persistance persistance = new Persistance(Environment.CurrentDirectory, "personnages.xml");

            // Ajouter un personnage à la persistance
            persistance.AddPersonnage(new Personnage(200, "Aatrox", "aatroximg", "to", "mi", "Autrefois, Aatrox et ses frères étaient honorés pour avoir défendu Shurima" +
                " contre le Néant. Mais ils finirent par devenir une menace plus grande encore pour Runeterra : la ruse et la sorcellerie furent employées pour les battre." +
                "Cependant, après des siècles d'emprisonnement, Aatrox fut le premier à retrouver sa liberté, en corrompant et transformant les mortels assez stupides pour tenter" +
                " de s'emparer de l'arme magique qui contenait son essence. Désormais en possession d'un corps qu'il a approximativement transformé pour rappeler son ancienne" +
                " forme, il arpente Runeterra en cherchant à assouvir sa vengeance apocalyptique.", null));

            // Récupérer le premier personnage de la persistance
            Personnage existingPersonnage = persistance.personnages.FirstOrDefault();

            // Vérifier que l'URL de l'image du personnage est correcte avant la mise à jour
            Assert.AreEqual("aatrox1.jpg", existingPersonnage.ImageUrl);

            // Mettre à jour le personnage avec de nouvelles valeurs
            existingPersonnage.ImageUrl = "aatrox1.jpg";


        }
    }
}