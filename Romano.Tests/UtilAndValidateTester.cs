using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Romano.Tests
{
    public class UtilAndValidateTester
    {
        [Theory]
        [InlineData("IX", 1, 'I')]
        [InlineData("IX", 0, null)]
        public void LeftOrNullTest(string roman, int index, char? expected)
        {
            var result = Util.LeftOrNull(roman, index, RomanizerOptions.DEFAULT_STRICT);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData("IX", 0, 'X')]
        [InlineData("IX", 1, null)]
        public void RightOrNullTest(string roman, int index, char? expected)
        {
            var result = Util.RightOrNull(roman, index, RomanizerOptions.DEFAULT_STRICT);
            
            Assert.Equal(expected,result);
        }

        [Fact]
        public void ConvertSingleRomanToDecimalTest()
        {
            foreach (var (roman, arabic) in Constants.ROMAN_NUMBERS)
            {
                var result = Util.ConvertSingleRomanToDecimal(roman);
                Assert.Equal(arabic,result);
            }
        }
        
        
        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentNullException))]
        [InlineData("  ", typeof(ArgumentNullException))]
        [InlineData("ABC", typeof(ArgumentException))]
        [InlineData("123", typeof(ArgumentException))]
        [InlineData("XXXX", typeof(ArgumentException))]
        [InlineData("XXXXXX", typeof(ArgumentException), RomanizerOptions.ALLOW_FOUR_SEQUENTIAL_DIGITS)]
        public void InvalidRomanToHumanTest(string roman, Type @throw, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            Assert.Throws(@throw, () => Romano.Humanize(roman, options) as object);
           // Assert.False(Romano.IsValidRoman(roman));
        }
        
        /*
        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentNullException))]
        [InlineData("  ", typeof(ArgumentNullException))]
        [InlineData("ABC", typeof(ArgumentException))]
        [InlineData("123", typeof(ArgumentException))]
        [InlineData("XXXX", typeof(ArgumentException))]
        [InlineData("XXXXXX", typeof(ArgumentException), RomanizerOptions.ALLOW_FOUR_SEQUENTIAL_DIGITS)]
        public void InvalidHumanToHumanTest(double arabic, Type @throw, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            Assert.Throws(@throw, () => Romano.Romanize(arabic, options) as object);
        }*/
        
        [Theory]
        [InlineData("XXXXX",RomanizerOptions.DEFAULT_STRICT, typeof(ArgumentException))]
        public void ValidateHumanizeOptions(string roman, RomanizerOptions options, Type @throw)
        {
            Assert.Throws(@throw, () => Romano.Humanize(roman, options) as object);
        }
    }
}