using System;
using System.Linq;
using Romano.Exceptions;

namespace Romano
{
    public static partial class Romano
    {
        private static char[] JUST_ONE_CAN_SUBSTRACT = {'V', 'X'};
        private static char[] JUST_TEN_CAN_SUBSTRACT = {'L', 'M', 'C'};
        public static bool IsValidRoman(string roman) => Validate.IsValidRoman(roman);
        public static ushort Humanize(string roman, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return HumanizeUnsafe(Validate.RomanNumber(roman, options), options);
        }

        internal static ushort HumanizeUnsafe(string roman, RomanizerOptions options)
        {
            ushort total = 0, index = 0;
            do
            {
                var number = roman[index];
                var left = Util.LeftOrNullUnsafe(roman, index);
                var right = Util.RightOrNullUnsafe(roman, index);
                var currentValue = Util.ConvertSingleRomanToDecimal(number);
                var rightDecimal = CheckRightDecimalSpecialRules(options, left, right, number);
                index++;
                
                var hasRightValue = rightDecimal > 0;
                var needSubtractFromRightDecimal = hasRightValue && rightDecimal > currentValue;
                if (needSubtractFromRightDecimal)
                {
                    total += (ushort) (rightDecimal - currentValue);
                    index++;
                    continue;
                }

                total += currentValue;
            } while (index < roman.Length);

            return total;
        }


        private static ushort CheckRightDecimalSpecialRules(RomanizerOptions options, char? left, char? right, char number)
        {
            if(right is not null && right.HasValue)
            {
                var rightDecimal = Util.ConvertSingleRomanToDecimal(right.Value);
                var needCheckSpecialRules = left.HasValue && right.HasValue;
                if (needCheckSpecialRules)
                {
                    CheckSpecialRules(left!.Value, right!.Value, number, rightDecimal, options);
                }

                return rightDecimal;
            }
            return 0;
        }
        

        private static void CheckSpecialRules(char left, char right, char current, int rightValue,
            RomanizerOptions options)
        {
            var isNotStrict = !options.HasFlag(RomanizerOptions.DEFAULT_STRICT);
            if (isNotStrict)
                return;

            var isAddition = Util.ConvertSingleRomanToDecimal(current) >= rightValue;
            if (isAddition)
            {
                CheckAdditionSpecialRules(current, rightValue, options);
            }
            else
            {
                CheckSubtractionSpecialRules(left, right, current, options);
            }
        }

        private static void CheckAdditionSpecialRules(char current, int rightValue, RomanizerOptions options)
        {
            
        }

        private static void CheckSubtractionSpecialRules(char left, char right, char current, RomanizerOptions options)
        {
            if (JUST_ONE_CAN_SUBSTRACT.Contains(right) && current != 'I')
                throw new ArithmeticSubtractionException(left, right, $"Invalid left '{left}' right '{right}' with strict rule (default) enabled you cant subtract '{right}' by '{left}'");
            if (JUST_TEN_CAN_SUBSTRACT.Contains(right) && current != 'X')
                throw new ArithmeticSubtractionException(left, right, $"Invalid left '{left}' right '{right}' with strict rule (default) enabled you cant subtract '{right}' by '{left}'");
        }
    }
}