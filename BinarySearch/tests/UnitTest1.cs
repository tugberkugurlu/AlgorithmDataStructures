using System;
using app;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void FindsTheCorrectIndex_WhenElementExists()
        {
            var sortedArray = new [] { 1, 2, 3, 4, 7, 9, 10, 11, 12, 13 };
            for (int i = 0; i < sortedArray.Length; i++)
            {
                var el = sortedArray[i];
                var foundIndex = Program.FindIndexOfElement(sortedArray, el);

                Assert.Equal(i, foundIndex);
            }
        }

        [Fact]
        public void ReturnsMinusOne_WhenElementDoesNotExists()
        {
            var sortedArray = new [] { 1, 2, 3, 4, 7, 9, 10, 11, 12, 13 };
            var foundIndex = Program.FindIndexOfElement(sortedArray, 8);
            Assert.Equal(-1, foundIndex);
        }
    }
}
