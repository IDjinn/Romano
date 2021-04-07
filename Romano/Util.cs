using System;

namespace Romano
{

    [Flags]
    public enum RomanizerOptions
    {
        DEFAULT_STRICT = 0, 
        ALLOW_FOUR_SEQUENTIAL_DIGITS = 1 << 0 | DEFAULT_STRICT, 
        ALLOW_MULTIPLE_SEQUENTIAL_DIGITS = 2 << 0 | ALLOW_FOUR_SEQUENTIAL_DIGITS, 
        
        USE_UNICODE = 3 << 0,
        USE_UNICODE_LOWER_CASE = 4 <<0
    }
    
    public static class Util
    {
        public static char? LeftOrNull(string roman, int index, RomanizerOptions options)
        {
            return LeftOrNullUnsafe(Validate.RomanNumber(roman, options), index);
        }

        internal static char? LeftOrNullUnsafe(string roman, int index)
        {
            var isValidRange = --index < roman.Length && index >= 0;
            return isValidRange ? roman[index] : null;
        }

        public static char? RightOrNull(string roman, int index, RomanizerOptions options)
        {
            return RightOrNullUnsafe(Validate.RomanNumber(roman, options), index);
        }

        internal static char? RightOrNullUnsafe(string roman, int index)
        {
            var isValidRange = ++index < roman.Length && index >= 0;
            return isValidRange ? roman[index] : null;
        }

        public static ushort ConvertSingleRomanToDecimal(char roman)
        {
            var isValidNumber = Constants.ROMAN_NUMBERS.ContainsKey(roman);
            if (isValidNumber)
            {
                return Constants.ROMAN_NUMBERS[roman];
            }
            
            throw new ArgumentException($"Invalid roman char: {roman}");
        }
    }
}