using AmbushTest.Directions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Windows;

namespace AmbushTest.Test
{
    [TestClass]
    public class RoverTest
    {
        private Rover rover;
        private IDirection directionMock;
        private Plateau plateauMock;
        private Point origin = new Point(0, 0);

        [TestInitialize()]
        public void MyTestInitialize()
        {
            directionMock = Substitute.For<IDirection>();
            plateauMock = Substitute.For<Plateau>();
            rover = new Rover(origin, directionMock, plateauMock, null);
        }

        [TestMethod]
        public void TestRotateLeft()
        {
            directionMock.RotateLeft().Returns(new EastDirection());
            
            rover.RotateLeft();

            directionMock.Received().RotateLeft();
        }

        [TestMethod]
        public void TestRotateRight()
        {
            directionMock.RotateLeft().Returns(new WestDirection());

            rover.RotateRight();

            directionMock.Received().RotateRight();
        }

        [TestMethod]
        public void TestMoveWithinBorders()
        {
            Point y = new Point(1, 2);
            directionMock.GetMovePosition(origin).Returns(y);
            plateauMock.IsWithinBorders(y).Returns(true);

            rover.Move();

            Assert.AreEqual(y, rover.Position);
        }

        [TestMethod]
        public void TestMoveNotWithinBorders()
        {
            Point newPosition = new Point(1, 2);
            directionMock.GetMovePosition(origin).Returns(newPosition);
            plateauMock.IsWithinBorders(newPosition).Returns(false);

            rover.Move();

            Assert.AreEqual(origin, rover.Position);
        }

        [TestMethod]
        public void TestToString()
        {
            directionMock.DirectionToString().Returns("N");
            var expectedString = string.Format("{0} {1} {2}", origin.X, origin.Y, "N");

            var roverToString = rover.ToString();

            Assert.AreEqual(expectedString, roverToString);
        }
    }
}
