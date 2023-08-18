using System;

namespace ToyRobot.Commands
{
    public class Move : ICommand
    {
        private Board _board;
        private Robot _robot;

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
                _board.PlaceAtPosition(newPosition);
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