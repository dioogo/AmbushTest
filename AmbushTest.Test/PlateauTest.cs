using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace AmbushTest.Test
{
    [TestClass]
    public class PlateauTest
    {
        private Plateau plateau;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            plateau = new Plateau(new Point(5, 5));
        }

        [TestMethod]
        public void TestIsWithinBordersWithXAndYLess()
        {
            Point newPoint = new Point(0, 0);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsTrue(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXLessAndYEqual()
        {
            Point newPoint = new Point(0, 5);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsTrue(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXLessAndYGreater()
        {
            Point newPoint = new Point(0, 6);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXEqualAndYLess()
        {
            Point newPoint = new Point(5, 0);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsTrue(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXAndYEqual()
        {
            Point newPoint = new Point(5, 5);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsTrue(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXEqualAndYGreater()
        {
            Point newPoint = new Point(5, 6);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXGreaterAndYLess()
        {
            Point newPoint = new Point(6, 0);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void testIsWithinBordersWithXGreaterAndYEqual()
        {
            Point newPoint = new Point(6, 5);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXAndYGreater()
        {
            Point newPoint = new Point(6, 6);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXNegativeAndYEqual0()
        {
            Point newPoint = new Point(-1, 0);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXNegativeAndMaxY()
        {
            Point newPoint = new Point(-1, 5);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXNegativeAndYGreater()
        {
            Point newPoint = new Point(-1, 6);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXAndYNegatives()
        {
            Point newPoint = new Point(-1, -1);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }


        [TestMethod]
        public void TestIsWithinBordersWithXEqual0AndYNegative()
        {
            Point newPoint = new Point(0, -1);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithMaxXAndYNegative()
        {
            Point newPoint = new Point(5, -1);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }

        [TestMethod]
        public void TestIsWithinBordersWithXGreaterAndYNegative()
        {
            Point newPoint = new Point(6, -1);

            var isWithinBorders = plateau.IsWithinBorders(newPoint);

            Assert.IsFalse(isWithinBorders);
        }
    }
}
