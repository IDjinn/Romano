using System;
using Xunit;

namespace Romano.Tests
{
    public class HumanizerTests
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("VII", 7)]
        [InlineData("VIII", 8)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        public void HumanizerTil10(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }
        
        [Theory]
        [InlineData("XI", 11)]
        [InlineData("XII", 12)]
        [InlineData("XIII", 13)]
        [InlineData("XIV", 14)]
        [InlineData("XV", 15)]
        [InlineData("XVI", 16)]
        [InlineData("XVII", 17)]
        [InlineData("XVIII", 18)]
        [InlineData("XIX", 19)]
        [InlineData("XX", 20)]
        public void HumanizerTil20(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }
        
        [Theory]
        [InlineData("XXI", 21)]
        [InlineData("XXII", 22)]
        [InlineData("XXIII", 23)]
        [InlineData("XXIV", 24)]
        [InlineData("XXV", 25)]
        [InlineData("XXVI", 26)]
        [InlineData("XXVII", 27)]
        [InlineData("XXVIII", 28)]
        [InlineData("XXIX", 29)]
        [InlineData("XXX", 30)]
        public void HumanizerTil30(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }
        
        [Theory]
        [InlineData("XXXI", 31)]
        [InlineData("XXXII", 32)]
        [InlineData("XXXIII", 33)]
        [InlineData("XXXIV", 34)]
        [InlineData("XXXV", 35)]
        [InlineData("XXXVI", 36)]
        [InlineData("XXXVII", 37)]
        [InlineData("XXXVIII", 38)]
        [InlineData("XXXIX", 39)]
        [InlineData("XL", 40)]
        public void HumanizerTil40(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }
        

        [Theory]
        [InlineData("XLI", 41)]
        [InlineData("XLII", 42)]
        [InlineData("XLIII", 43)]
        [InlineData("XLIV", 44)]
        [InlineData("XLV", 45)]
        [InlineData("XLVI", 46)]
        [InlineData("XLVII", 47)]
        [InlineData("XLVIII", 48)]
        [InlineData("XLIX", 49)]
        [InlineData("XLX", 50)]
        public void HumanizerTil50(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }

        [Theory]
        [InlineData("XLXI", 51)]
        [InlineData("XLXII", 52)]
        [InlineData("XLXIII", 53)]
        [InlineData("XLXIV", 54)]
        [InlineData("XLXV", 55)]
        [InlineData("XLXVI", 56)]
        [InlineData("XLXVII", 57)]
        [InlineData("XLXVIII", 58)]
        [InlineData("XLXIX", 59)]
        [InlineData("XLXX", 60)]
        public void HumanizerTil60(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }
        
        [Theory]
        [InlineData("XLXXI", 61)]
        [InlineData("XLXXII", 62)]
        [InlineData("XLXXIII", 63)]
        [InlineData("XLXXIV", 64)]
        [InlineData("XLXXV", 65)]
        [InlineData("XLXXVI", 66)]
        [InlineData("XLXXVII",67)]
        [InlineData("XLXXVIII", 68)]
        [InlineData("XLXXIX", 69)]
        [InlineData("XLXXX", 70)]
        public void HumanizerTil70(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }

        [Theory]
        [InlineData("XLXXXI", 71)]
        [InlineData("XLXXXII", 72)]
        [InlineData("XLXXXIII", 73)]
        [InlineData("XLXXXIV", 74)]
        [InlineData("XLXXXV", 75)]
        [InlineData("XLXXXVI", 76)]
        [InlineData("XLXXXVII",77)]
        [InlineData("XLXXXVIII", 78)]
        [InlineData("XLXXXIX", 79)]
        [InlineData("XLXL", 80)]
        public void HumanizerTil80(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }

        [Theory]
        [InlineData("XLXLI", 81)]
        [InlineData("XLXLII", 82)]
        [InlineData("XLXLIII", 83)]
        [InlineData("XLXLIV", 84)]
        [InlineData("XLXLV", 85)]
        [InlineData("XLXLVI", 86)]
        [InlineData("XLXLVII",87)]
        [InlineData("XLXLVIII", 88)]
        [InlineData("XLXLIX", 89)]
        [InlineData("XLXLX", 90)]
        public void HumanizerTil90(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }
        
        [Theory]
        [InlineData("XCI", 91)]
        [InlineData("XCII", 92)]
        [InlineData("XCIII", 93)]
        [InlineData("XCIV", 94)]
        [InlineData("XCV", 95)]
        [InlineData("XCVI", 96)]
        [InlineData("XCVII",97)]
        [InlineData("XCVIII", 98)]
        [InlineData("XCIX", 99)]
        [InlineData("C", 100)]
        public void HumanizerTil100(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }
        
        
        [Theory]
        [InlineData("C", 100)]
        [InlineData("CC", 200)]
        [InlineData("CCC", 300)]
        [InlineData("D", 500)]
        [InlineData("DD", 1000)]
        [InlineData("DDD", 1500)]
        [InlineData("M", 1000)]
        [InlineData("MM", 2000)]
        [InlineData("MMM", 3000)]
        [InlineData("MMCCXXIX", 2229)]
        [InlineData("MMMDCCCXXVI", 3826 )]
        public void HumanizerBigNumbers(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }

        [Theory]
        [InlineData("XLXLX", 90)]
        public void HumanizeSpecial(string romanNumber, int expected)
        {
            HumanizeTester(romanNumber, expected);
        }

        private void HumanizeTester(string romanNumber, int expected)
        {
            int result = Romano.Humanize(romanNumber);
            Assert.Equal(expected,result);
        }
    }
}