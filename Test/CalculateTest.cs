using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Test
{
    [TestClass]
    public class CalculateTest
    {
        public string testInput = "12*15";

        [TestMethod]
        public void DoesCalculateReturnAnInt()
        {
            var p = new Calculate(testInput);
            Assert.AreEqual(p.getResult().GetType(), typeof(int));
        }


        [TestMethod]
        public void CanCalculateFindOperand()
        {
            var p = new Calculate(testInput);
            Assert.AreEqual(p.operand, '*');
        }


        [TestMethod]
        public void CanCalculateFindFirstNumeral()
        {
            var p = new Calculate(testInput);
            Assert.AreEqual(p.firstNumeral, 12);

        }

        [TestMethod]
        public void CanCalculateFindSecondNumeral()
        {
            var p = new Calculate(testInput);
            Assert.AreEqual(p.secondNumeral, 15);
        }


        [TestMethod]
        public void CanCalculateGetCorrectResult()
        {
            var p = new Calculate(testInput);
            Assert.AreEqual(p.getResult(), 180);
        }


    }
}

