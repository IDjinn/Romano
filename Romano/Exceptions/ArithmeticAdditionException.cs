using System;

namespace Romano.Exceptions
{
    public class ArithmeticAdditionException : Exception
    {
        public string Roman { get; init; }
        public char Current { get; init; }
        public byte TotalRepeated { get; init; }
        public ArithmeticAdditionException(string roman, char current, byte totalRepeated, string message) : base(message)
        {
            Roman = roman;
            Current = current;
            TotalRepeated = totalRepeated;
        }
    }
}