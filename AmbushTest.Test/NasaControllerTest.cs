using AmbushTest.Commands;
using AmbushTest.Directions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AmbushTest.Test
{
    [TestClass]
    public class NasaControllerTest
    {
        private readonly MoveCommand moveCommandMock = Substitute.For<MoveCommand>();
        private readonly RotateLeftCommand rotateLeftCommandMock = Substitute.For<RotateLeftCommand>();
        private readonly RotateRightCommand rotateRightCommandMock = Substitute.For<RotateRightCommand>();
        private List<ICommand> commands;

        private NasaParser nasaParserMock;

        private NasaController controller;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            commands = new List<ICommand>
            {
                moveCommandMock,
                rotateLeftCommandMock,
                rotateRightCommandMock
            };

            nasaParserMock = Substitute.For<NasaParser>();

            controller = new NasaController(nasaParserMock);
        }

        [TestMethod]
        public void TestExecuteWithNoRover()
        {
            nasaParserMock.ReadFile().Returns(new List<Rover>());

            var rovers = controller.Execute();

            Assert.IsFalse(rovers.Any());
        }

        [TestMethod]
        public void TestExecuteWithOneRover()
        {
            var rover = new Rover(new Point(1, 1), new EastDirection(), new Plateau(new Point(5, 5)), commands);
            var rovers = new List<Rover> { rover };

            nasaParserMock.ReadFile().Returns(rovers);

            var rovers2 = controller.Execute();

            moveCommandMock.Received().Execute(rover);
            rotateLeftCommandMock.Received().Execute(rover);
            rotateRightCommandMock.Received().Execute(rover);

            Assert.IsTrue(rovers.Any());
        }

        [TestMethod]
        public void TestExecuteWithTwoRovers()
        {
            var rover = new Rover(new Point(1, 1), new EastDirection(), new Plateau(new Point(5, 5)), commands);
            var rover2 = new Rover(new Point(3, 3), new NorthDirection(), new Plateau(new Point(5, 5)), commands);
            var rovers = new List<Rover> { rover, rover2 };

            nasaParserMock.ReadFile().Returns(rovers);

            var newRovers = controller.Execute();

            Assert.AreEqual(2, newRovers.Count);
            Assert.IsTrue(newRovers[0].Direction is EastDirection);
            Assert.IsTrue(newRovers[1].Direction is NorthDirection);

            moveCommandMock.Received().Execute(rover);
            rotateLeftCommandMock.Received().Execute(rover);
            rotateRightCommandMock.Received().Execute(rover);

            moveCommandMock.Received().Execute(rover2);
            rotateLeftCommandMock.Received().Execute(rover2);
            rotateRightCommandMock.Received().Execute(rover2);
        }
    }
}
