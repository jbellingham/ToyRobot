using System;

namespace ToyRobot
{
    public class Board
    {
        private readonly int _size;
        private Robot _robot;

        public Board(Robot robot, int size = 5)
        {
            _robot = robot;
            _size = size;
        }


        public bool PlaceAtPosition(Position position)
        {
            var successful = true;
            if (CanPlaceAtPosition(position))
            {
                _robot.UpdatePosition(position);
            }
            else
            {
                // Output from failed placement is confusing (tile index starting at zero so it says cannot place at position 5, 5 for a board size of 5 for example)
                Console.WriteLine($"Attempted to place at {position.X}, {position.Y} - but board size is {_size}");
                successful = false;
            }

            return successful;
        }

        private bool CanPlaceAtPosition(Position position)
        {
            return position.X >= 0 && position.X <= _size - 1 &&
                   position.Y >= 0 && position.Y <= _size - 1;
        }
    }
}