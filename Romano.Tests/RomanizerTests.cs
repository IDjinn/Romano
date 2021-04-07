using System;
using BenchmarkDotNet.Attributes;
using Xunit;

namespace Romano.Tests
{
    public class RomanizerTests
    {
        [Benchmark]
        [Theory]
        [InlineData(12, "XII")]
        [InlineData(21,"XXI")]
        [InlineData(22,"XXII")]
        [InlineData(23,"XXIII")]
        [InlineData(30,"XXX")]
        public void ToRomanTest(ushort number, string expect)
        {
            var result = Romano.Romanize(number);
            Assert.Equal(expect,result);
        }
    }
}