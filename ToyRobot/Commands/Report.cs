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
            Console.WriteLine($"{_robot.Position.X},{_robot.Position.Y},{_robot.Position.Facing.ToString()}");
        }
    }

    private bool CanExecute()
    {
        return _robot.IsPlaced;
    }
}