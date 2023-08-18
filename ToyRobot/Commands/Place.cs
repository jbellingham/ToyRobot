namespace ToyRobot.Commands
{
    public class Place : ICommand
    {
        private Board _board;
        private Position _position;
        
        public Place(Board board, Position position)
        {
            _board = board;
            _position = position;
        }

        public void Execute()
        {
            _board.PlaceAtPosition(_position);
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}