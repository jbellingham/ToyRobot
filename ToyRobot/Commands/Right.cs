namespace ToyRobot.Commands
{
    public class Right : ICommand
    {
        private readonly Robot _robot;

        public Right(Robot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                _robot.UpdateFacing(this);
            }
        }

        private bool CanExecute()
        {
            return _robot.IsPlaced;
        }
    }
}