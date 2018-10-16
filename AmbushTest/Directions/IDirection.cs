using System.Windows;

namespace AmbushTest.Directions
{
    public interface IDirection
    {
        IDirection RotateRight();

        IDirection RotateLeft();

        string DirectionToString();

        Point GetMovePosition(Point _roverPosition);
    }
}
