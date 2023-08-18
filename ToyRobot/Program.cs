using System;
using System.Globalization;
using System.IO;
using ToyRobot.Commands;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var board = new Board(robot);

            var lines = File.ReadLines("input/in2.txt");
            foreach (var line in lines)
            {
                var split = line.Split(' ');
                var commandString = split[0];
                ICommand command;
                switch (commandString)
                {
                    case "PLACE":
                        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                        var positionSplit = split[1].Split(',');
                        var facingString = textInfo.ToTitleCase(positionSplit[2].ToLower());
                        
                        command = new Place(
                            board,
                            new Position(
                                Enum.Parse<Facing>(facingString),
                                Int32.Parse(positionSplit[0]),
                                Int32.Parse(positionSplit[1])));
                        break;
                    case "MOVE":
                        command = new Move(board, robot);
                        break;
                    case "LEFT":
                        command = new Left(robot);
                        break;
                    case "RIGHT":
                        command = new Right(robot);
                        break;
                    case "REPORT":
                        command = new Report(robot);
                        break;
                    default:
                        throw new InvalidOperationException("Input document contained an unexpected command.");
                }
                command.Execute();
            }
        }
    }
}