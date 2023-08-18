namespace ToyRobot.Commands
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }
}