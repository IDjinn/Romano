using System;

namespace Romano.Exceptions
{
    public class ArithmeticSubtractionException : Exception
    {
        public readonly char Left;
        public readonly char Right;
        public ArithmeticSubtractionException(char left, char right, string message) : base(message)
        {
            Left = left;
            Right = right;
        }
    }
}