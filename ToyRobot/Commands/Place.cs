namespace ToyRobot.Commands
{
    public class Place : ICommand
    {
        private readonly Board _board;
        private readonly Position _position;
        
        public Place(Board board, Position position)
        {
            _board = board;
            _position = position;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                _board.PlaceAtPosition(_position);
            }
        }

        private static bool CanExecute()
        {
            return true;
        }
    }
}