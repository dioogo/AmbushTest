using AmbushTest.Directions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Abstractions.TestingHelpers;

namespace AmbushTest.Test
{
    [TestClass]
    public class NasaParserTest
    {
        [TestMethod]
        public void TestReadFileWithEmptyFile()
        {
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(@"C:\Temp\AmbushTest.txt", MockFileData.NullObject);
            mockFileSystem.File.WriteAllText(@"C:\Temp\AmbushTest.txt", "");
            
            var nasaParser = new NasaParser(mockFileSystem);

            var rovers = nasaParser.ReadFile();

            Assert.AreEqual(0, rovers.Count);
        }

        [TestMethod]
        public void TestReadFileWithOnePlateau()
        {
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(@"C:\Temp\AmbushTest.txt", MockFileData.NullObject);
            mockFileSystem.File.WriteAllText(@"C:\Temp\AmbushTest.txt", "5 5");

            var nasaParser = new NasaParser(mockFileSystem);

            var rovers = nasaParser.ReadFile();

            Assert.AreEqual(0, rovers.Count);
        }

        [TestMethod]
        public void TestReadFileWithOneRover()
        {
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(@"C:\Temp\AmbushTest.txt", MockFileData.NullObject);
            mockFileSystem.File.WriteAllText(@"C:\Temp\AmbushTest.txt", "7 1\n1 2 N\nLMLMLMLMM");

            var nasaParser = new NasaParser(mockFileSystem);

            var rovers = nasaParser.ReadFile();

            Assert.AreEqual(1, rovers.Count);

            Assert.AreEqual(1, rovers[0].Position.X);
            Assert.AreEqual(2, rovers[0].Position.Y);
            Assert.IsTrue(rovers[0].Direction is NorthDirection);
            Assert.AreEqual(9, rovers[0].Commands.Count);
            Assert.AreEqual(7, rovers[0].MarsPlateu.Coordinates.X);
            Assert.AreEqual(1, rovers[0].MarsPlateu.Coordinates.Y);
        }

        [TestMethod]
        public void TestReadFileWithTwoRovers()
        {
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(@"C:\Temp\AmbushTest.txt", MockFileData.NullObject);
            mockFileSystem.File.WriteAllText(@"C:\Temp\AmbushTest.txt", "7 1\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMM");

            var nasaParser = new NasaParser(mockFileSystem);

            var rovers = nasaParser.ReadFile();

            Assert.AreEqual(2, rovers.Count);

            Assert.AreEqual(1, rovers[0].Position.X);
            Assert.AreEqual(2, rovers[0].Position.Y);
            Assert.IsTrue(rovers[0].Direction is NorthDirection);
            Assert.AreEqual(9, rovers[0].Commands.Count);
            Assert.AreEqual(7, rovers[0].MarsPlateu.Coordinates.X);
            Assert.AreEqual(1, rovers[0].MarsPlateu.Coordinates.Y);

            Assert.AreEqual(3, rovers[1].Position.X);
            Assert.AreEqual(3, rovers[1].Position.Y);
            Assert.IsTrue(rovers[1].Direction is EastDirection);
            Assert.AreEqual(5, rovers[1].Commands.Count);
            Assert.AreEqual(7, rovers[1].MarsPlateu.Coordinates.X);
            Assert.AreEqual(1, rovers[1].MarsPlateu.Coordinates.Y);
        }

    }
}
