using Mediatheque.Core.Model;
using Mediatheque.Core.Service;

namespace Mediatheque.CoreTests.ModelTests.JeuxDeSocieteTests
{
    [TestClass]
    public class ReturnAllJeux
    {
        [TestMethod]
        public void GetListeJeuxEmpty()
        {
            // Arrange
            MediathequeService mediathequeService = new MediathequeService(null);

            // Act
            string actual = mediathequeService.GetNombreJeux();

            // Assert
            Assert.AreEqual("Pas de jeux", actual);
        }

        [TestMethod]
        public void GetListeJeuxOnlyCDs()
        {
            // Arrange
            MediathequeService mediathequeService = new MediathequeService(null);
            mediathequeService.AddObjet(new CD("Spice world", "Spice girl"));
            mediathequeService.AddObjet(new CD("Smash", "Offspring"));

            // Act
            string actual = mediathequeService.GetNombreJeux();

            // Assert
            Assert.AreEqual("Pas de jeux", actual);
        }

        [TestMethod]
        public void GeJeuxWhenOnlyJeuxExist()
        {
            // Arrange
            MediathequeService mediathequeService = new MediathequeService(null);
            mediathequeService.AddObjet(new JeuxDeSociete("Jeux de 54 cartes", 3, 99, "carrefour", TypeJeuxDeSociete.Carte));
            mediathequeService.AddObjet(new JeuxDeSociete("Echec", 3, 99, "superU", TypeJeuxDeSociete.Pion));
            mediathequeService.AddObjet(new JeuxDeSociete("monopoly", 3, 99, "auchan", TypeJeuxDeSociete.Plateau));

            // Act
            string actual = mediathequeService.GetNombreJeux();

            // Assert
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void GeJeuxWhenJeuxAndCDsExists()
        {
            // Arrange
            MediathequeService mediathequeService = new MediathequeService(null);
            mediathequeService.AddObjet(new JeuxDeSociete("Jeux de 54 cartes", 3, 99, "carrefour", TypeJeuxDeSociete.Carte));
            mediathequeService.AddObjet(new JeuxDeSociete("Echec", 3, 99, "superU", TypeJeuxDeSociete.Pion));
            mediathequeService.AddObjet(new CD("Spice world", "Spice girl"));
            mediathequeService.AddObjet(new CD("Smash", "Offspring"));

            // Act
            string actual = mediathequeService.GetNombreJeux();

            // Assert
            Assert.AreEqual("2", actual);
        }
    }
}
