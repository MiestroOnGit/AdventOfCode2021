using System;
using System.Collections.Generic;

namespace DayOne.solvers.DayTwo
{
    public record struct Instruction
    {
        private Direction direction;

        public Direction Direction => direction;

        public int Magnitude => magnitude;

        private int magnitude;

        public Instruction(string instructionString)
        {
            string[] input = instructionString.Split(" ");
            direction = Enum.Parse<Direction>(input[0], true);
            magnitude = Convert.ToInt32(input[1]);
        }
    }

    public enum Direction
    {
        UP,
        DOWN,
        FORWARD
    }

    public class DiveSolver
    {
        private int _xPos;
        private int _depth;
        private int _pitch;
        private bool useAngle;

        public DiveSolver(bool useAngle)
        {
            this.useAngle = useAngle;
            _pitch = 0;
            _xPos = 0;
            _depth = 0;
        }
        
        public int solve(IEnumerable<string> input)
        {
            foreach (string instrStr in input)
            {
                Instruction inst = new Instruction(instrStr);

                switch (inst.Direction)
                {
                    case Direction.UP:
                        if (useAngle)
                            _pitch -= inst.Magnitude;
                        else
                            _depth -= inst.Magnitude;
                        break;
                    case Direction.DOWN:
                        if (useAngle)
                            _pitch += inst.Magnitude;
                        else
                            _depth += inst.Magnitude;
                        break;
                    case Direction.FORWARD:
                        if (useAngle)
                        {
                            _xPos += inst.Magnitude;
                            _depth += inst.Magnitude * _pitch;
                        }
                        else
                            _xPos += inst.Magnitude;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return _xPos * _depth;
        }
    }
}