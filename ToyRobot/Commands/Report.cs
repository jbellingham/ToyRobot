using System;

namespace ToyRobot.Commands;

public class Report : ICommand
{
    private readonly Robot _robot;

    public Report(Robot robot)
    {
        _robot = robot;
    }

    public void Execute()
    {
        if (CanExecute())
        {
            var currentPosition = _robot.GetCurrentPosition();
            Console.WriteLine($"{currentPosition.X},{currentPosition.Y},{currentPosition.Facing.ToString()}");
        }
        else
        {
            Console.WriteLine("Couldn't execute REPORT command - robot has not been placed yet.");
        }
    }

    private bool CanExecute()
    {
        return _robot.IsPlaced;
    }
}