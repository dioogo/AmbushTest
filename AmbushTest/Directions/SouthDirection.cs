using System.Windows;

namespace AmbushTest.Directions
{
    public class SouthDirection : IDirection
    {
        private readonly static Point DirectionPoint = new Point(0, -1);

        public string DirectionToString()
        {
            return "S";
        }

        public IDirection RotateLeft()
        {
            return new EastDirection();
        }

        public IDirection RotateRight()
        {
            return new WestDirection();
        }
        public Point GetMovePosition(Point _roverPosition)
        {
            Point movePosition = new Point(_roverPosition.X + DirectionPoint.X, _roverPosition.Y + DirectionPoint.Y);
            return movePosition;
        }
    }
}
