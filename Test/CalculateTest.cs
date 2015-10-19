using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Test
{
    [TestClass]
    public class CalculateTest
    {
        //test parseInput

        //test calculateresponse
        [TestMethod]
        public void CalculateResponseReturnsStringResponse()
        {
            string input = "4+7";
            var calc = new Calculate(input);
            var response = calc.CalculateResponse(new int[] { 1, 7 }, '+');
            Assert.AreEqual(response, "8");
        }

        [TestMethod]
        public void FindsLastInInput()
        {
            string input = "last";
            Stack.lastResponse = "65";
            var calc = new Calculate(input);
            calc.inputIsntGoingToBeCalculated(input);
            Assert.AreEqual(Calculate.response, Stack.lastResponse);
        }
        [TestMethod]
        public void lastLastqAndExitQuitDoNotNeedToBeCalculated()
        {
            string input = "lastq";
            Stack.lastResponse = "5*13";
            var calc = new Calculate(input);
            bool isGonna = calc.inputIsntGoingToBeCalculated(input);
            Assert.AreEqual(true, isGonna);
        }
        [TestMethod]
        public void FindsExitOrQuitInInput()
        {
            string input = "exit";
            var calc = new Calculate(input);
            calc.inputIsntGoingToBeCalculated(input);
            Assert.AreEqual(Calculate.response, "goodbye, fool");
        }
    }

}

