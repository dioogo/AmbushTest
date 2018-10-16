using System.Windows;

namespace AmbushTest.Directions
{
    public class WestDirection : IDirection
    {
        private readonly static Point DirectionPoint = new Point(-1, 0);

        public string DirectionToString()
        {
            return "W";
        }

        public IDirection RotateLeft()
        {
            return new SouthDirection();
        }

        public IDirection RotateRight()
        {
            return new NorthDirection();
        }

        public Point GetMovePosition(Point _roverPosition)
        {
            Point movePosition = new Point(_roverPosition.X + DirectionPoint.X, _roverPosition.Y + DirectionPoint.Y);
            return movePosition;
        }
    }
}
