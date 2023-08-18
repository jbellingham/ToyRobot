using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests
{
    public class RightTests
    {
        [Theory]
        [InlineData(Facing.North, Facing.East)]
        [InlineData(Facing.East, Facing.South)]
        [InlineData(Facing.South, Facing.West)]
        [InlineData(Facing.West, Facing.North)]
        public void RightCommand_ChangesFacingAppropriatelyAccordingToCurrentFacing(Facing current, Facing expected)
        {
            var robot = new Robot(new Position(current, 3, 3));
            var rightCommand = new Right(robot);
            rightCommand.Execute();

            robot.Position.Facing.Should().Be(expected);
        }
    }
}