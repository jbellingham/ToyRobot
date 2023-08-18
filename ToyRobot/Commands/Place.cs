namespace ToyRobot.Commands
{
    public class Place : ICommand
    {
        private Board _board;
        private Robot _robot;
        
        public Place(Board board, Robot robot)
        {
            _board = board;
            _robot = robot;
        }

        public bool Execute()
        {
            return _board.PlaceAtPosition(_robot.Position);
        }
    }
}