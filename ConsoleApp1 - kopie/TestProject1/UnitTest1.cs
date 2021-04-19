using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PassingTest()
        {
            Assert.AreEqual(4, Calculator.Add(2,2));
        }

        [Test]
        public void FailingTest()
        {
            Assert.AreNotEqual(5, Calculator.Add(2,2));
        }

        [Test]
        public void PassingTest2()
        {
            Assert.AreEqual(1, Calculator.Subtract(2, 1));
        }
    }
}