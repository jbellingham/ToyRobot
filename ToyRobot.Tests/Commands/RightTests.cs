using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests.Commands;

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

        robot.GetCurrentPosition().Facing.Should().Be(expected);
    }

    [Fact]
    public void RightCommand_DoesNotChangeRobotsXYPositionOnTheBoard()
    {
        var position = new Position(Facing.East, 3, 3);
        var robot = new Robot(position);
        var rightCommand = new Right(robot);
        rightCommand.Execute();

        robot.GetCurrentPosition().X.Should().Be(position.X);
        robot.GetCurrentPosition().Y.Should().Be(position.Y);
    }
}