using System;
using System.IO;
using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests.Commands;

public class PlaceTests
{
    [Fact]
    public void PlaceCommand_WillNotPlaceRobotAboveVerticalBounds()
    {
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var robot = new Robot();
        var board = new Board(robot, 5);
        var initialPosition = robot.GetCurrentPosition();
        var placeCommand = new Place(board, new Position(Facing.East, 3, 6));
            
        placeCommand.Execute();

        robot.GetCurrentPosition().Should().BeEquivalentTo(initialPosition);
    }
        
    [Fact]
    public void PlaceCommand_WillNotPlaceRobotBelowVerticalBounds()
    {
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var robot = new Robot();
        var board = new Board(robot, 5);
        var initialPosition = robot.GetCurrentPosition();
        var placeCommand = new Place(board, new Position(Facing.East, 3, -1));
            
        placeCommand.Execute();

        robot.GetCurrentPosition().Should().BeEquivalentTo(initialPosition);
    }
        
    [Fact]
    public void PlaceCommand_WillNotPlaceRobotAboveHorizontalBounds()
    {
        var robot = new Robot();
        var board = new Board(robot, 5);
        var initialPosition = robot.GetCurrentPosition();
        var placeCommand = new Place(board, new Position(Facing.East, 6, 3));
            
        placeCommand.Execute();

        robot.GetCurrentPosition().Should().BeEquivalentTo(initialPosition);
    }
        
    [Fact]
    public void PlaceCommand_WillNotPlaceRobotBelowHorizontalBounds()
    {
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var robot = new Robot();
        var board = new Board(robot, 5);
        var initialPosition = robot.GetCurrentPosition();
        var placeCommand = new Place(board, new Position(Facing.East, -1, 3));
            
        placeCommand.Execute();

        robot.GetCurrentPosition().Should().BeEquivalentTo(initialPosition);
    }

    [Fact]
    public void PlaceCommand_WillPlaceRobotWithinBoardsBounds()
    {
        var robot = new Robot();
        var board = new Board(robot, 5);
        var validPosition = new Position(Facing.East, 3, 3);
        var placeCommand = new Place(board, validPosition);
            
        placeCommand.Execute();

        robot.GetCurrentPosition().Should().BeEquivalentTo(validPosition);
    }
}