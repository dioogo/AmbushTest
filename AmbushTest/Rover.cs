using AmbushTest.Commands;
using AmbushTest.Directions;
using System.Collections.Generic;
using System.Windows;

namespace AmbushTest
{
    public class Rover
    {
        public Point Position { get; set; }
        public IDirection Direction { get; set; }
        public Plateau MarsPlateu { get; set; }
        public List<ICommand> Commands { get; set; }

        public Rover() { }

        public Rover(Point _position, IDirection _direction, Plateau _plateau, List<ICommand> _commands)
        {
            Position = _position;
            Direction = _direction;
            MarsPlateu = _plateau;
            Commands = _commands;
        }

        public virtual void RotateLeft()
        {
            Direction = Direction.RotateLeft();
        }
        public virtual void RotateRight()
        {
            Direction = Direction.RotateRight();
        }

        public virtual void Move()
        {
            Point x = Direction.GetMovePosition(Position);
            if (MarsPlateu.IsWithinBorders(x))
                Position = x;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Position.X, Position.Y, Direction.DirectionToString());
        }
    }
}
