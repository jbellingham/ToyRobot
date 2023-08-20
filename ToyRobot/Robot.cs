using ToyRobot.Commands;

namespace ToyRobot
{
    public class Robot
    {
        private Position _position;
        public bool IsPlaced => _position.X >= 0 && _position.Y >= 0;

        public Robot(Position position)
        {
            _position = position;
        }

        public Robot()
        {
            _position = new Position(Facing.East, -1, -1);
        }
        
        public void UpdatePosition(Position position)
        {
            _position = position;
        }

        public Position GetNextPositionInCurrentFacing()
        {
            return _position.GetNextPositionInCurrentFacing();
        }

        public void UpdateFacing(ICommand command)
        {
            _position.UpdateFacing(command);
        }

        public Position GetCurrentPosition()
        {
            return new Position(_position.Facing, _position.X, _position.Y);
        }
    }
}