using AmbushTest.Directions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace AmbushTest.Test.Directions
{
    [TestClass]
    public class NorthDirectionTest
    {
        IDirection direction;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            direction = new NorthDirection();
        }

        [TestMethod]
        public void TestRotateLeft()
        {
            var newDirection = direction.RotateLeft();
            Assert.IsTrue(newDirection is WestDirection);
        }

        [TestMethod]
        public void TestRotateRight()
        {
            var newDirection = direction.RotateRight();
            Assert.IsTrue(newDirection is EastDirection);
        }

        [TestMethod]
        public void TestToString()
        {
            var directionStringFormat = direction.DirectionToString();
            Assert.AreEqual("N", directionStringFormat);
        }

        [TestMethod]
        public void TestGetMovePosition()
        {
            Point origin = new Point(0, 0);
            Point expectedPosition = new Point(0, 1);

            var newPosition = direction.GetMovePosition(origin);

            Assert.AreEqual(expectedPosition.X, newPosition.X);
            Assert.AreEqual(expectedPosition.Y, newPosition.Y);
        }
    }
}
