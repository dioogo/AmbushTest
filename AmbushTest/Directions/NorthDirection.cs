using System.Windows;

namespace AmbushTest.Directions
{
    public class NorthDirection : IDirection
    {
        private readonly static Point DirectionPoint = new Point(0, 1);
        public string DirectionToString()
        {
            return "N";
        }

        public IDirection RotateLeft()
        {
            return new WestDirection();
        }

        public IDirection RotateRight()
        {
            return new EastDirection();
        }

        public Point GetMovePosition(Point _roverPosition)
        {
            Point movePosition = new Point(_roverPosition.X + DirectionPoint.X, _roverPosition.Y + DirectionPoint.Y);
            return movePosition;
        }
    }
}
