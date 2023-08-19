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

            var lines = File.ReadLines("input/in.txt");
            foreach (var line in lines)
            {
                var split = line.Split(' ');
                var commandString = split[0].ToLower();
                ICommand command;
                switch (commandString)
                {
                    case "place":
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
                    case "move":
                        command = new Move(board, robot);
                        break;
                    case "left":
                        command = new Left(robot);
                        break;
                    case "right":
                        command = new Right(robot);
                        break;
                    case "report":
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