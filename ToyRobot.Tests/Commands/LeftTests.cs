using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests.Commands;

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
        
    [Fact]
    public void LeftCommand_DoesNotChangeRobotsXYPositionOnTheBoard()
    {
        var position = new Position(Facing.East, 3, 3);
        var robot = new Robot(position);
        var rightCommand = new Left(robot);
        rightCommand.Execute();

        robot.Position.X.Should().Be(position.X);
        robot.Position.Y.Should().Be(position.Y);
    }
}