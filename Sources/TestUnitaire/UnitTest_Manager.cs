using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SAE2._01.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void Test_SelectedCharacter_Setter()
        {
            // Arrange
            var persistance = new Persistance(Environment.CurrentDirectory, "personnages.xml");
            var manager = new Manager(persistance);
            var character1 = new Personnage(1, "Character 1", "image1.jpg", "Role 1", "Role 2", "Histoire 1", new Dictionary<string, Competences>());
            var character2 = new Personnage(2, "Character 2", "image2.jpg", "Role 3", "Role 4", "Histoire 2", new Dictionary<string, Competences>());

            // Act
            manager.SelectedCharacter = character1;

            // Assert
            Assert.AreEqual(character1, manager.SelectedCharacter);

            // Act
            manager.SelectedCharacter = character2;

            // Assert
            Assert.AreEqual(character2, manager.SelectedCharacter);
        }

        [TestMethod]
        public void Test_DictionaryValues()
        {
            // Arrange
            var persistance = new Persistance(Environment.CurrentDirectory, "personnages.xml");
            var manager = new Manager(persistance);
            var character = new Personnage(1, "Character", "image.jpg", "Role 1", "Role 2", "Histoire", new Dictionary<string, Competences>());
            character.dic.Add("Comp1", new Competences(TypeCompetence.Passif, "Nom1", "Description1"));
            character.dic.Add("Comp2", new Competences(TypeCompetence.Classique, "Nom2", "Description2"));

            // Act
            manager.SelectedCharacter = character;
            var dictionaryValues = manager.SelectedCharacter.dic;

            // Assert
            Assert.AreEqual(2, dictionaryValues.Count);
            Assert.AreEqual(manager.SelectedCharacter.dic["Comp1"].Type, TypeCompetence.Passif);
            Assert.AreEqual(manager.SelectedCharacter.dic["Comp2"].Type , TypeCompetence.Classique);
            Assert.AreEqual(manager.SelectedCharacter.dic["Comp1"].Nom,"Nom1");
            Assert.AreEqual(manager.SelectedCharacter.dic["Comp2"].Nom,"Nom2");
            Assert.AreEqual(manager.SelectedCharacter.dic["Comp1"].Description, "Description1");
            Assert.AreEqual(manager.SelectedCharacter.dic["Comp2"].Description, "Description2");
        }

        [TestMethod]
        public void Test_LoadPersonnages()
        {
            // Arrange
            var persistance = new Persistance(Environment.CurrentDirectory, "personnages.xml");

            // Créer un fichier "personnages.xml" valide dans le répertoire de persistance
            var personnages = persistance.personnages;

            Assert.IsNotNull(personnages);

            persistance.SaveData(personnages);

            var manager = new Manager(persistance);

            // Act
            var loadedPersonnages = persistance.LoadData().ToList();

            // Assert
            Assert.IsNotNull(loadedPersonnages);
            Assert.AreEqual(personnages.Count, loadedPersonnages.Count);
        }
    }
}
