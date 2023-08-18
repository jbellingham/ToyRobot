using System;
using System.IO;
using FluentAssertions;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests;

public class ReportTests
{
    [Theory]
    [InlineData(Facing.East, 2, 3)]
    [InlineData(Facing.North, 0, 1)]
    [InlineData(Facing.West, 4, 4)]
    [InlineData(Facing.South, 1, 2)]
    public void ReportCommand_AnnouncesCorrectPositionInExpectedFormat(Facing facing, int x, int y)
    {
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var position = new Position(facing, x, y);
        var robot = new Robot(position);
        var reportCommand = new Report(robot);
        
        reportCommand.Execute();
        stringWriter.ToString().Should().Be($"{x},{y},{facing}{Environment.NewLine}");
    }
}