using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests
{
    public class MoveTests
    {
        [Fact]
        public void MoveCommand_CannotBeExecutedIfRobotHasNotBeenPlaced()
        {
            var robot = new Robot();
            var initialPosition = robot.GetCurrentPosition();
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }

        [Fact]
        public void MoveCommand_WhenFacingNorth_MovesUp()
        {
            var initialPosition = new Position(Facing.North, 3, 3);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(new Position(Facing.North, initialPosition.X, initialPosition.Y + 1));
        }
        
        [Fact]
        public void MoveCommand_WhenFacingSouth_MovesDown()
        {
            var initialPosition = new Position(Facing.South, 3, 3);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(new Position(Facing.South, initialPosition.X, initialPosition.Y -1));
        }
        
        [Fact]
        public void MoveCommand_WhenFacingEast_MovesRight()
        {
            var initialPosition = new Position(Facing.East, 3, 3);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(new Position(Facing.East, initialPosition.X + 1, initialPosition.Y));
        }
        
        [Fact]
        public void MoveCommand_WhenFacingWest_MovesLeft()
        {
            var initialPosition = new Position(Facing.West, 3, 3);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(new Position(Facing.West, initialPosition.X - 1, initialPosition.Y));
        }

        [Fact]
        public void MoveCommand_WhenFacingNorth_CannotMoveAboveVerticalBounds()
        {
            var initialPosition = new Position(Facing.North, 3, 4);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }
        
        [Fact]
        public void MoveCommand_WhenFacingSouth_CannotMoveBelowVerticalBounds()
        {
            var initialPosition = new Position(Facing.South, 3, 0);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }
        
        [Fact]
        public void MoveCommand_WhenFacingEast_CannotMoveRightOutsideHorizontalBounds()
        {
            var initialPosition = new Position(Facing.East, 4, 4);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }
        
        [Fact]
        public void MoveCommand_WhenFacingWest_CannotMoveLeftOutsideHorizontalBounds()
        {
            var initialPosition = new Position(Facing.West, 0, 4);
            var robot = new Robot(initialPosition);
            var board = new Board(robot, 5);
            var moveCommand = new Move(board, robot);
            moveCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }
    }
}