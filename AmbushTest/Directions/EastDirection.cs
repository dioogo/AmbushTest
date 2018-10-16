using System.Windows;

namespace AmbushTest.Directions
{
    public class EastDirection : IDirection
    {
        private readonly static Point DirectionPoint = new Point(1, 0);
        public string DirectionToString()
        {
            return "E";
        }

        public IDirection RotateLeft()
        {
            return new NorthDirection();
        }

        public IDirection RotateRight()
        {
            return new SouthDirection();
        }

        public Point GetMovePosition(Point _roverPosition)
        {
            Point movePosition = new Point(_roverPosition.X + DirectionPoint.X, _roverPosition.Y + DirectionPoint.Y);
            return movePosition;
        }
    }
}
