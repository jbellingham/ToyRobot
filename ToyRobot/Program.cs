using System;
using System.Globalization;
using System.IO;
using ToyRobot.Commands;

namespace ToyRobot;

class Program
{
    static void Main(string[] args)
    {
        var robot = new Robot();
        var board = new Board(robot);

        var lines = File.ReadLines("input/in.txt");
        foreach (var line in lines)
        {
            var command = ParseCommand(line, board, robot);
            command.Execute();
        }
    }

    private static ICommand ParseCommand(string line, Board board, Robot robot)
    {
        ICommand command;
        
        // the place command is expected to be in two parts separated by a space
        // splitting on the space gives us the place command in the first element of the array
        // and coords and facing information in the second element of the array.
        // 
        // For all other commands, we just get a single element in the split array,
        // the command string
        var split = line.Split(' ');
            
        var textInfo = CultureInfo.CurrentCulture.TextInfo;
        // we ToLower() the file input, and then ToTitleCase() the result,
        // meaning we can receive e.g. pLaCE, or PLACE, or pLACE or place,
        // but we'll always end up with Place
        var commandString = textInfo.ToTitleCase(split[0].ToLower());
        switch (commandString)
        {
            // Which then means that we can do this instead of matching cases on magic strings
            case nameof(Place):
                var positionSplit = split[1].Split(',');
                var facingString = textInfo.ToTitleCase(positionSplit[2].ToLower());

                command = new Place(
                    board,
                    new Position(
                        Enum.Parse<Facing>(facingString),
                            int.Parse(positionSplit[0]),
                            int.Parse(positionSplit[1])));
                break;
            case nameof(Move):
                command = new Move(board, robot);
                break;
            case nameof(Left):
                command = new Left(robot);
                break;
            case nameof(Right):
                command = new Right(robot);
                break;
            case nameof(Report):
                command = new Report(robot);
                break;
            default:
                throw new InvalidOperationException("Input document contained an unexpected command.");
        }

        return command;
    }
}