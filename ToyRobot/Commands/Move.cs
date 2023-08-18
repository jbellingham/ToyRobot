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

        public bool Execute()
        {
            var newPosition = _robot.Move();
            return _board.PlaceAtPosition(newPosition);
        }
    }
}