using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Romano
{
    public static partial class Romano
    {
        public const ushort MAX_VALUE = 3_999;
        public const string MAX_VALUE_ROMAN = "MMMCMXCIX";
        private static IEnumerable<KeyValuePair<char,ushort>> romanNumbersReversed = Constants.ROMAN_NUMBERS.Reverse();

        public static bool IsValidHuman(ushort number) => Validate.IsValidNumber(number);
        
        public static string Romanize(ushort number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            var validNumber = Validate.HumanNumber(number);
            return RomanizeUnsafe(validNumber, options);
        }

        internal static string RomanizeUnsafe(ushort number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            StringBuilder roman = new(MAX_VALUE_ROMAN.Length);
            do
            {
                for (var i = 0; i < romanNumbersReversed.Count(); i++)
                {
                    var (romanDigit, decimalDigit) = romanNumbersReversed.ElementAt(i);
                    if (number < decimalDigit) continue;
                    
                    var count = (ushort)Math.Round((double)(number / decimalDigit));
                    
                    /*
                     * Special rule
                     *
                     * When the number have free 4 units, need subtract then by higher value for not throw 4 sum limit.
                     *
                     * Example: IIII => IV
                     */
                    var isSpecialCountRule = count == 4 && !options.HasFlag(RomanizerOptions.ALLOW_FOUR_SEQUENTIAL_DIGITS);
                    if (isSpecialCountRule)
                    {
                        var higherValueIndex = i - 1;
                        var (rightRomanDigit, rightDigit) = romanNumbersReversed.ElementAtOrDefault(higherValueIndex);
                        var existRightValue = rightRomanDigit != 0 && rightDigit > 0;
                        /*
                         * Need check if have higher value to subtract free units
                         */
                        if (existRightValue) 
                        {
                            roman.Append(romanDigit);
                            roman.Append(rightRomanDigit);
                            number -= (ushort)(decimalDigit * count);
                            break;
                        }
                    }
                    /*
                     * Special rule end
                     */
                    
                    for (var j = 0; j < count; j++)
                    {
                        roman.Append(romanDigit);
                    }
                    number -= (ushort)(decimalDigit * count);
                    break;
                }
            } while (number > 0);

            return roman.ToString();
        }
    }
}