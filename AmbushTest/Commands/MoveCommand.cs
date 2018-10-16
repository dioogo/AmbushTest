namespace AmbushTest.Commands
{
    public class MoveCommand : ICommand
    {
        public void Execute(Rover _rover)
        {
            _rover.Move();
        }
    }
}