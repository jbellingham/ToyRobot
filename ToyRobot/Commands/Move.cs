using System;

namespace ToyRobot.Commands
{
    public class Move : ICommand
    {
        private readonly Board _board;
        private readonly Robot _robot;

        public Move(Board board, Robot robot)
        {
            _board = board;
            _robot = robot;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                var newPosition = _robot.Move();
                var moved = _board.PlaceAtPosition(newPosition);
                if (!moved)
                {
                    Console.WriteLine($"Attempted to move to {newPosition.X}, {newPosition.Y} - but board size is {_board.Size}");
                }
            }
            else
            {
                Console.WriteLine("Couldn't execute MOVE command - robot has not been placed yet.");
            }
        }

        public bool CanExecute()
        {
            return _robot.IsPlaced;
        }
    }
}