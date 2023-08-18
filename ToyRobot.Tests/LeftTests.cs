using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests
{
    public class LeftTests
    {
        [Theory]
        [InlineData(Facing.North, Facing.West)]
        [InlineData(Facing.East, Facing.North)]
        [InlineData(Facing.South, Facing.East)]
        [InlineData(Facing.West, Facing.South)]
        public void LeftCommand_ChangesFacingAppropriatelyAccordingToCurrentFacing(Facing current, Facing expected)
        {
            var robot = new Robot(new Position(current, 3, 3));
            var leftCommand = new Left(robot);
            leftCommand.Execute();

            robot.Position.Facing.Should().Be(expected);
        }
    }
}