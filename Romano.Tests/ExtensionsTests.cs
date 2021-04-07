using System.Threading.Tasks;
using Xunit;

namespace Romano.Tests
{
    public class ExtensionsTests
    {
        [Theory]
        [InlineData("X" , 10)]
        public void StringToRomanTest(string str, int expected)
        {
            Assert.Equal(expected, str.Humanize());
        }
        
        [Theory]
        [InlineData(10, "X")]
        public void NumberToRomanTest(ushort number, string expected)
        {
            Assert.Equal(expected, number.Romanizer());
        }
        
        [Fact]
        public void ExtensionTwoFactTest()
        {
            Parallel.For(1, Romano.MAX_VALUE + 1, arabic =>
            {
                var roman = arabic.Romanizer();
                Assert.Equal(roman.Humanize(), arabic);
            });
        }
    }
}