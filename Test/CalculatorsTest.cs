using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Test
{
    [TestClass]
    public class CalculatorsTest
    {
        [TestMethod]
        public void AddTest()
        {
            int first = 1;
            int second = 2;
            var adder = new Add();
            Assert.AreEqual(3, adder.Calculate(first, second));
        }

        [TestMethod]
        public void SubtractTest()
        {
            int first = 1;
            int second = 2;
            var subtracter = new Subtract();
            Assert.AreEqual(-1, subtracter.Calculate(first, second));
        }

        [TestMethod]
        public void MultiplyTest()
        {
            int first = 2;
            int second = 2;
            var multiplier = new Multiply();
            Assert.AreEqual(4, multiplier.Calculate(first, second));
        }

        [TestMethod]
        public void DivideTest()
        {
            int first = 10;
            int second = 2;
            var divider = new Divide();
            Assert.AreEqual(5, divider.Calculate(first, second));
        }

        [TestMethod]
        public void ModulusTest()
        {
            int first = 11;
            int second = 2;
            var modulus = new Modulus();
            Assert.AreEqual(1, modulus.Calculate(first, second));
        }
    }
}
