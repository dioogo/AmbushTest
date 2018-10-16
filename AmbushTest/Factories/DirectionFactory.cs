using AmbushTest.Directions;

namespace AmbushTest.Factories
{
    public class DirectionFactory
    {
        public static IDirection CreateDirection(char _direction)
        {
            IDirection roverDirection = null;
            switch (_direction)
            {
                case 'N':
                    roverDirection = new NorthDirection();
                    break;
                case 'W':
                    roverDirection = new WestDirection();
                    break;
                case 'S':
                    roverDirection = new SouthDirection();
                    break;
                case 'E':
                    roverDirection = new EastDirection();
                    break;
                default: break;
            }

            return roverDirection;
        }
    }
}
