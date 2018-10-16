namespace AmbushTest.Commands
{
    public class RotateRightCommand : ICommand
    {
        public void Execute(Rover _rover)
        {
            _rover.RotateRight();
        }
    }
}
