using System;
using ToyRobot.Commands;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot(new Position(Facing.East, 2, 3));
            var board = new Board(robot);
            ICommand command = new Place(board, robot);
            command.Execute();

            command = new Move(board, robot);
            command.Execute();
            command.Execute();
            command.Execute();
        }
    }
}