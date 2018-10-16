using AmbushTest.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AmbushTest.Test.Commands
{
    [TestClass]
    public class RotateLeftCommandTest
    {
        ICommand command;
        Rover roverMock;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            command = new RotateLeftCommand();
            roverMock = Substitute.For<Rover>();
        }

        [TestMethod]
        public void TesteExecuteRotateLeftWasCalled()
        {
            command.Execute(roverMock);

            roverMock.Received().RotateLeft();
        }
    }
}
