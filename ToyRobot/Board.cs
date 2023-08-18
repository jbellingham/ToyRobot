using System;

namespace ToyRobot
{
    public class Board
    {
        public int Size { get; }
        private readonly Robot _robot;

        public Board(Robot robot, int size = 5)
        {
            _robot = robot;
            Size = size;
        }


        public bool PlaceAtPosition(Position position)
        {
            var success = false;
            if (CanPlaceAtPosition(position))
            {
                _robot.UpdatePosition(position);
                success = true;
            }

            return success;
        }

        private bool CanPlaceAtPosition(Position position)
        {
            return position.X >= 0 && position.X <= Size - 1 &&
                   position.Y >= 0 && position.Y <= Size - 1;
        }
    }
}