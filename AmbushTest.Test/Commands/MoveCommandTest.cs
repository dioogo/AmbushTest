using AmbushTest.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AmbushTest.Test.Commands
{
    [TestClass]
    public class MoveCommandTest
    {
        ICommand command;
        Rover roverMock;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            command = new MoveCommand();
            roverMock = Substitute.For<Rover>();
        }

        [TestMethod]
        public void TesteExecuteMoveWasCalled()
        {
            command.Execute(roverMock);

            roverMock.Received().Move();
        }
    }
}
