using AmbushTest.Directions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace AmbushTest.Test.Directions
{
    [TestClass]
    public class EastDirectionTest
    {
        IDirection direction;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            direction = new EastDirection();
        }

        [TestMethod]
        public void TestRotateLeft()
        {
            var newDirection = direction.RotateLeft();
            Assert.IsTrue(newDirection is NorthDirection);
        }

        [TestMethod]
        public void TestRotateRight()
        {
            var newDirection = direction.RotateRight();
            Assert.IsTrue(newDirection is SouthDirection);
        }

        [TestMethod]
        public void TestToString()
        {
            var directionStringFormat = direction.DirectionToString();
            Assert.AreEqual("E", directionStringFormat);
        }

        [TestMethod]
        public void TestGetMovePosition()
        {
            Point origin = new Point(0, 0);
            Point expectedPosition = new Point(1, 0);

            var newPosition = direction.GetMovePosition(origin);

            Assert.AreEqual(expectedPosition.X, newPosition.X);
            Assert.AreEqual(expectedPosition.Y, newPosition.Y);
        }
    }
}
