using System;

namespace ToyRobot
{
    public class Robot
    {
        public Position Position;
        public bool IsPlaced => Position.X >= 0 && Position.Y >= 0;

        public Robot(Position position)
        {
            Position = position;
        }

        public Robot()
        {
            Position = new Position(Facing.East, -1, -1);
        }
        
        public void UpdatePosition(Position position)
        {
            Position = position;
            Console.WriteLine($"New position is:" +
                              $"\nX: {Position.X}" +
                              $"\nY: {Position.Y}" +
                              $"\nFacing: {Position.Facing}");
        }

        public Position Move()
        {
            return Position.MovePosition();
        }

        public Position GetCurrentPosition()
        {
            return new Position(Position.Facing, Position.X, Position.Y);
        }
    }
}