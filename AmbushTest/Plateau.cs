using System.Windows;

namespace AmbushTest
{
    public class Plateau
    {
        public Point Coordinates { get; set; }

        public Plateau() { }

        public Plateau(Point _coordinates)
        {
            Coordinates = _coordinates;
        }

        public virtual bool IsWithinBorders(Point _coordinates)
        {
            bool withinBorders = (_coordinates.X <= Coordinates.X && _coordinates.Y <= Coordinates.Y) && (_coordinates.X >= 0 && _coordinates.Y >= 0);
            return withinBorders;
        }
    }
}
