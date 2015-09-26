using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Test
{
    [TestClass]
    public class ParserTest
    {
        public string testInput = "12*15";

        [TestMethod]
        public void DoesParserReturnAnInt()
        {
            var p = new Parser(testInput);
            Assert.AreEqual(p.getResult().GetType(), typeof(int));
        }


        [TestMethod]
        public void CanParserFindOperand()
        {
            var p = new Parser(testInput);
            Assert.AreEqual(p.operand, '*');
        }


        [TestMethod]
        public void CanParserFindFirstNumeral()
        {
            var p = new Parser(testInput);
            Assert.AreEqual(p.firstNumeral, 12);

        }

        [TestMethod]
        public void CanParserFindSecondNumeral()
        {
            var p = new Parser(testInput);
            Assert.AreEqual(p.secondNumeral, 15);
        }


        [TestMethod]
        public void CanParserGetCorrectResult()
        {
            var p = new Parser(testInput);
            Assert.AreEqual(p.getResult(), 180);
        }
        
    }
}
