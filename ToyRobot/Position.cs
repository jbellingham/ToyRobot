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

            public Position MovePosition()
            {
                if (Facing == Facing.North)
                {
                    return new Position(Facing, X, Y + 1);
                }
                if (Facing == Facing.East)
                {
                    return new Position(Facing, X + 1, Y);
                }
                if (Facing == Facing.South)
                {
                    return new Position(Facing, X, Y - 1);
                }
                if (Facing == Facing.West)
                {
                    return new Position(Facing, X - 1, Y);
                }

                // not sure about this
                return this;
            }

            public void UpdateFacing(ICommand command)
            {
                var firstFacing = Enum.GetValues(typeof(Facing)).Cast<Facing>().First();
                var lastFacing = Enum.GetValues(typeof(Facing)).Cast<Facing>().Last();
                if (command is Right)
                {
                    if (Facing == lastFacing)
                    {
                        Facing = firstFacing;
                    }
                    else
                    {
                        Facing += 1;
                    }
                }

                // if (command is Left)
                // {
                //     Facing -= 1;
                // }
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