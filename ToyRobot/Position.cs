using System;
using System.Linq;
using ToyRobot.Commands;

namespace ToyRobot
{
        public class Position
        {
            public int X;
            public int Y;
            public Facing Facing;

            public Position(Facing facing, int x, int y)
            {
                Facing = facing;
                X = x;
                Y = y;
            }

            public Position GetNextPositionInCurrentFacing()
            {
                return Facing switch
                {
                    Facing.North => new Position(Facing, X, Y + 1),
                    Facing.East => new Position(Facing, X + 1, Y),
                    Facing.South => new Position(Facing, X, Y - 1),
                    Facing.West => new Position(Facing, X - 1, Y),
                    _ => this
                    // not sure about this ^.
                    // With the current implementation, there's not really a way to get here...
                    // We parse out the facing from the command input, and if we can't parse it will just blow up haha...
                    // Still probably unexpected behaviour here if that underlying parsing mechanism ever changed.
                };
            }

            public void UpdateFacing(ICommand command)
            {
                // this little thingo assumes that the facing enum values stay in clockwise order
                var firstFacing = Enum.GetValues(typeof(Facing)).Cast<Facing>().First();
                var lastFacing = Enum.GetValues(typeof(Facing)).Cast<Facing>().Last();
                switch (command)
                {
                    case Right when Facing == lastFacing:
                        Facing = firstFacing;
                        break;
                    case Right:
                        Facing += 1;
                        break;
                    case Left when Facing == firstFacing:
                        Facing = lastFacing;
                        break;
                    case Left:
                        Facing -= 1;
                        break;
                }
            }
        }

        public enum Facing
        {
            North,
            East,
            South,
            West
        }
}