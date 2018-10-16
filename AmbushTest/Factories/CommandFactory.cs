using AmbushTest.Commands;

namespace AmbushTest.Factories
{
    public class CommandFactory
    {
        public static ICommand CreateCommand(char _command)
        {
            ICommand command = null;
            switch (_command)
            {
                case 'R':
                    command = new RotateRightCommand();
                    break;
                case 'L':
                    command = new RotateLeftCommand();
                    break;
                case 'M':
                    command =new MoveCommand();
                    break;
                default: break;
            }

            return command;
        }
    }
}
