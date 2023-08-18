using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests
{
    public class PlaceTests
    {
        [Fact]
        public void RobotCannotBePlacedAboveVerticalBounds()
        {
            var robot = new Robot();
            var board = new Board(robot, 5);
            var initialPosition = robot.GetCurrentPosition();
            var placeCommand = new Place(board, new Position(Facing.East, 3, 6));
            
            placeCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }
        
        [Fact]
        public void RobotCannotBePlacedBelowVerticalBounds()
        {
            var robot = new Robot();
            var board = new Board(robot, 5);
            var initialPosition = robot.GetCurrentPosition();
            var placeCommand = new Place(board, new Position(Facing.East, 3, -1));
            
            placeCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }
        
        [Fact]
        public void RobotCannotBePlacedAboveHorizontalBounds()
        {
            var robot = new Robot();
            var board = new Board(robot, 5);
            var initialPosition = robot.GetCurrentPosition();
            var placeCommand = new Place(board, new Position(Facing.East, 6, 3));
            
            placeCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }
        
        [Fact]
        public void RobotCannotBePlacedBelowHorizontalBounds()
        {
            var robot = new Robot();
            var board = new Board(robot, 5);
            var initialPosition = robot.GetCurrentPosition();
            var placeCommand = new Place(board, new Position(Facing.East, -1, 3));
            
            placeCommand.Execute();

            robot.Position.Should().BeEquivalentTo(initialPosition);
        }

        [Fact]
        public void RobotCanBePlacedWithinBoardsBounds()
        {
            var robot = new Robot();
            var board = new Board(robot, 5);
            var validPosition = new Position(Facing.East, 3, 3);
            var placeCommand = new Place(board, validPosition);
            
            placeCommand.Execute();

            robot.Position.Should().BeEquivalentTo(validPosition);
        }
    }
}