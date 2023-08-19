namespace ToyRobot.Commands
{
    public class Left : ICommand
    {
        private readonly Robot _robot;

        public Left(Robot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                // law of demeter violation
                // come back to this
                _robot.Position.UpdateFacing(this);
            }
        }

        private bool CanExecute()
        {
            return _robot.IsPlaced;
        }
    }
}