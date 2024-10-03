using NUnit.Framework;
using SimulateurRobotJouet;

namespace SimulateurRobotJouetTests
{
    [TestFixture]
    public class RobotTests
    {
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            robot = new Robot();
        }

        [Test]
        public void Placer_ValidPosition_SetsPositionAndDirection()
        {
            robot.Placer(0, 0, Direction.NORD);
            Assert.AreEqual("0,0,NORD", robot.Rapport());
        }

        [Test]
        public void Deplacer_ValidMove_MovesNorth()
        {
            robot.Placer(0, 0, Direction.NORD);
            robot.Deplacer();
            Assert.AreEqual("0,1,NORD", robot.Rapport());
        }

        [Test]
        public void Deplacer_EdgeOfTable_DoesNotMove()
        {
            robot.Placer(0, 4, Direction.NORD);
            robot.Deplacer();
            Assert.AreEqual("0,4,NORD", robot.Rapport()); // Ne doit pas bouger
        }

        [Test]
        public void Gauche_TurnLeft_ChangesDirection()
        {
            robot.Placer(0, 0, Direction.NORD);
            robot.Gauche();
            Assert.AreEqual("0,0,OUEST", robot.Rapport());
        }

        [Test]
        public void Droite_TurnRight_ChangesDirection()
        {
            robot.Placer(0, 0, Direction.NORD);
            robot.Droite();
            Assert.AreEqual("0,0,EST", robot.Rapport());
        }

        [Test]
        public void Rapport_NoPlaceCommand_ReturnsEmpty()
        {
            Assert.AreEqual(string.Empty, robot.Rapport());
        }

        [Test]
        public void Placer_InvalidPosition_Ignored()
        {
            robot.Placer(6, 6, Direction.NORD); // Position invalide
            Assert.AreEqual(string.Empty, robot.Rapport());
        }

        [Test]
        public void MultiplePlaceCommands_OnlyLastValidPlaceIsConsidered()
        {
            robot.Placer(0, 0, Direction.NORD);
            robot.Placer(2, 2, Direction.EST);
            robot.Placer(1, 1, Direction.SUD); // Dernier PLACE valide
            Assert.AreEqual("1,1,SUD", robot.Rapport());
        }
    }
}
