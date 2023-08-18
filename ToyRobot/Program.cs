using ToyRobot.Commands;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var board = new Board(robot);
            ICommand command = new Place(board, new Position(Facing.East, 3, 3));
            command.Execute();

            command = new Move(board, robot);
            command.Execute();
            command.Execute();
            command.Execute();
        }
    }
}