using System;

namespace ToyRobot.Commands;

public class Report : ICommand
{
    private Robot _robot;

    public Report(Robot robot)
    {
        _robot = robot;
    }

    public void Execute()
    {
        Console.WriteLine($"{_robot.Position.X},{_robot.Position.Y},{_robot.Position.Facing.ToString()}");
    }

    public bool CanExecute()
    {
        return _robot.IsPlaced;
    }
}