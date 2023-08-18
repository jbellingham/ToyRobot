using System;

namespace ToyRobot
{
    public class Robot
    {
        public Position Position;

        public Robot(Position position)
        {
            Position = position;
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
    }
}