using System;

namespace ToyRobot.Commands
{
    public class Left : ICommand
    {
        private readonly Robot _robot;

        public Left(Robot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                _robot.UpdateFacing(this);
            }
            else
            {
                Console.WriteLine("Couldn't execute LEFT command - robot has not been placed yet.");
            }
        }

        private bool CanExecute()
        {
            return _robot.IsPlaced;
        }
    }
}