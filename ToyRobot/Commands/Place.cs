using System;

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
                var placed = _board.PlaceAtPosition(_position);
                if (!placed)
                {
                    Console.WriteLine($"Attempted to place at {_position.X}, {_position.Y} - but board size is {_board.Size}");
                }
            }
        }

        private static bool CanExecute()
        {
            return true;
        }
    }
}