using System;
using System.Collections.Generic;
using System.Linq;
using Romano.Exceptions;

namespace Romano
{
    internal static class Validate
    {
        public static bool IsValidRoman(string? roman, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            if (roman is null)
                return false;
            
            if (string.IsNullOrEmpty(roman.Trim().ToUpper()))
                return false;

            var hasInvalidRomanDigit = roman.All(digit => Constants.ROMAN_NUMBERS.ContainsKey(digit)) is false;
            if (hasInvalidRomanDigit)
                return false;

            var hasRepeatedDigits = CheckRepeatedDigits(roman.Trim().ToUpper(), options) is not null;
            if (hasRepeatedDigits)
                return false;
            
            return true;
        }

        
        /// <summary>
        /// Validate a roman number
        /// </summary>
        /// <param name="roman">Roman number input</param>
        /// <param name="options">Options to parse this roman number</param>
        /// <returns>Valid roman number</returns>
        /// <exception cref="ArgumentNullException">Roman number can not be a null string</exception>
        /// <exception cref="ArgumentException">Invalid roman digit</exception>
        /// <exception cref="ArithmeticAdditionException">Parse not allowed by rules options</exception>
        public static string RomanNumber(string? roman, RomanizerOptions options)
        {
            if (string.IsNullOrEmpty(roman)) throw new ArgumentNullException(nameof(roman));

            string cleanRoman = roman.Trim().ToUpper();
            if (string.IsNullOrEmpty(cleanRoman)) throw new ArgumentNullException(nameof(roman));

            var hasInvalidRomanDigit = roman.All(digit => Constants.ROMAN_NUMBERS.ContainsKey(digit)) is false;
            if (hasInvalidRomanDigit) throw new ArgumentException($"Invalid roman char: {roman}");

            var exception = CheckRepeatedDigits(cleanRoman, options);
            var hasRepeatedDigits = exception is not null;
            if (hasRepeatedDigits) throw exception!;

            return cleanRoman;
        }
        
        public static bool IsValidNumber(int? human) => human > 0 && human < Romano.MAX_VALUE;

        internal static ushort HumanNumber(int? human)
        {
            switch (human)
            {
                case null:
                    throw new ArgumentNullException(nameof(human));
                case <= 0 or > Romano.MAX_VALUE:
                    throw new ArgumentOutOfRangeException(nameof(human));
            }
            
            return (ushort)human;
        }

        private static Exception? CheckRepeatedDigits(string roman, RomanizerOptions options)
        {
            var allowFourSum = options.HasFlag(RomanizerOptions.ALLOW_FOUR_SEQUENTIAL_DIGITS);
            var allowMultipleSum = options.HasFlag(RomanizerOptions.ALLOW_MULTIPLE_SEQUENTIAL_DIGITS);
            for (var i = 0; i < roman.Length; i++)
            {
                var current = roman[i];
                var totalRepeated = (byte)roman.Skip(i).TakeWhile(digit => digit == current).Count();
                switch (totalRepeated)
                {
                    case <= 3:
                        continue;
                    case 4 when !allowFourSum:
                        return new ArithmeticAdditionException(
                            roman, current, totalRepeated,
                            $"Roman number '{roman}' with multiple repeated digits of '{current}' with total '{totalRepeated}', so it is invalid roman number. If you want sum 4 digits you need allow this in options entry.");
                    case > 4 when !allowMultipleSum:
                        return new ArithmeticAdditionException(
                            roman, current, totalRepeated,
                            $"Roman number '{roman}' with multiple repeated digits of '{current}' with total '{totalRepeated}', so it is invalid roman number. If you want sum more than 4 digits you need allow this in options entry.");
                }
            }

            return null;
        }
    }
}