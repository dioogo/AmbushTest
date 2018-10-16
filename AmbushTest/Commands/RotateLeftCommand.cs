namespace AmbushTest.Commands
{
    public class RotateLeftCommand : ICommand
    {
        public void Execute(Rover _rover)
        {
            _rover.RotateLeft();
        }
    }
}
