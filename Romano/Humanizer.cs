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

                if (CalculateRightAndLeftOperationsAndSkip(left, currentValue, rightDecimal, ref total, ref index)) 
                    continue;

                total += currentValue;
            } while (index < roman.Length);

            return total;
        }

        private static bool CalculateRightAndLeftOperationsAndSkip(char? left, ushort currentValue, int rightDecimal, ref ushort total,
            ref ushort index)
        {
            var rightOperationsSuccess = TryCalculateRightValueAddition(currentValue, rightDecimal, ref total);
            if(rightOperationsSuccess)
                goto skiper;

            if (left is not null)
            {
                var leftSubtractionSuccess = TryCalculateLeftValueAndSubtract(left.Value, currentValue, ref total);
                if(leftSubtractionSuccess)
                    goto skiper;
            }

            return false;
            skiper:
            { 
                index++; 
                return true;
            }
        }

        private static int CheckRightDecimalSpecialRules(RomanizerOptions options, char? left, char? right, char number)
        {
            var rightDecimal = 0;
            var needCheckSpecialRules = left.HasValue && right.HasValue;
            if (needCheckSpecialRules)
            {
                rightDecimal = Util.ConvertSingleRomanToDecimal(right!.Value);
                CheckSpecialRules(left!.Value, right!.Value, number, rightDecimal, options);
            }

            return rightDecimal;
        }
        
        private static bool TryCalculateLeftValueAndSubtract(char left, ushort currentValue,ref ushort total)
        {
            var leftDecimal = Util.ConvertSingleRomanToDecimal(left);
            var needSubtractLeftValue = currentValue > leftDecimal;
            if (needSubtractLeftValue)
                total += (ushort) (currentValue - leftDecimal);
            
            return needSubtractLeftValue;
        }


        private static bool TryCalculateRightValueAddition(int currentValue, int rightDecimal, ref ushort total)
        {
            var needSubtractCurrentValue = currentValue < rightDecimal;
            if (needSubtractCurrentValue)
                total += (ushort) (rightDecimal - currentValue);

            return needSubtractCurrentValue;
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