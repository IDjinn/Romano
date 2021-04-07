using System.Threading.Tasks;
using Xunit;

namespace Romano.Tests
{
    public class DoubleFactorTests
    {
        [Fact]
        public void TwoFactorMainTest()
        {
            /*
             * Using parallel for multiple two factor tests
             */
            Parallel.For(1, Romano.MAX_VALUE + 1, i =>
            {
                var arabic = (ushort) i;
                var roman = Romano.Romanize(arabic);
                /*
                 * Basic roman two factor tests, with strict options
                 * IV
                 */
                Assert.Equal(arabic, Romano.Humanize(roman));
                
                /*
                 * Four sequential digits tests
                 * IIII
                 */
                roman = Romano.Romanize(arabic, RomanizerOptions.ALLOW_FOUR_SEQUENTIAL_DIGITS);
                Assert.Equal(arabic, Romano.Humanize(roman, RomanizerOptions.ALLOW_FOUR_SEQUENTIAL_DIGITS));

                /*
                 * Multiple sequential digits tests
                 * IIIII
                 */
                roman = Romano.Romanize(arabic, RomanizerOptions.ALLOW_MULTIPLE_SEQUENTIAL_DIGITS);
                Assert.Equal(arabic, Romano.Humanize(roman, RomanizerOptions.ALLOW_MULTIPLE_SEQUENTIAL_DIGITS));
            });
        }
    }
}