using System.Collections.Generic;

namespace Romano
{
    public static class Constants
    {
        public static Dictionary<char, ushort> ROMAN_NUMBERS = new()
        {
            {'I', 1},
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000},
        };
        
        public static Dictionary<char, ushort> ROMAN_NUMBER_UNICODE = new()
        {
            {'Ⅰ', 1},
            {'Ⅱ',2},
            {'Ⅲ',3},
            {'Ⅳ',4},
            {'Ⅴ',5},
            {'Ⅵ',6},
            {'Ⅶ',7},
            {'Ⅷ',8},
            {'Ⅸ',9},
            {'Ⅹ',10},
            {'Ⅺ',11},
            {'Ⅻ',12},
            {'Ⅼ',50},
            {'Ⅽ',100},
            {'Ⅾ',500},
            {'Ⅿ',1000},
        };
        
        public static Dictionary<char, ushort> ROMAN_NUMBER_UNICODE_LOWER_CASE = new()
        {
            {'ⅰ', 1},
            {'ⅱ',2},
            {'ⅲ',3},
            {'ⅳ',4},
            {'ⅴ',5},
            {'ⅵ',6},
            {'ⅶ',7},
            {'ⅷ',8},
            {'ⅸ',9},
            {'ⅹ',10},
            {'ⅺ',11},
            {'ⅻ',12},
            {'ⅼ',50},
            {'ⅽ',100},
            {'ⅾ',500},
            {'ⅿ',1000},
        };
    }
}