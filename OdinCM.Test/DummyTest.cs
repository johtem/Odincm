using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OdinCM.Test
{
    public class DummyTest
    {
        [Theory]
        [InlineData(2, 2)]
        public void PassingTest(int a, int b)
        {
            var test = Add(a, b);
            Assert.Equal(4, test);
        }

        [Fact]
        public void PassingFactTest()
        {
            Assert.NotEqual(4, 5);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }


    }
}
