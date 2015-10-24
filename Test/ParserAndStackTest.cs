//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Calculator;

//namespace Test
//{
//    [TestClass]
//    public class ParserAndStackTest
//    {

//        //1+2 or 4/2
//        [TestMethod]
//        public void DoesParserSplitonanOperand()
//        {
//            var input = "1*2";
//            var p = new Parser(input);
//            var terms = p.SplitOnOperand();
//            CollectionAssert.AreEqual(new string[] { "1", "2" }, terms);
//        }

//        // */ka or 9/4/2
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void ThrowsExceptionWhenGivenTwoOperands()
//        {
//            var input = "4/*4";
//            var p = new Parser(input);
//            var terms = p.SplitOnOperand();
//        }

//        // *87 or 2662-
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void ThrowsExceptionWhenOnly1Value()
//        {
//            var input = "33533/";
//            var p = new Parser(input);
//            var terms = p.SplitOnOperand();
//        }

//        //2*2 or 3+8
//        [TestMethod]
//        public void turnStringArrayToIntArrayWithoutConstants()
//        {
//            var input = "3*4";
//            var p = new Parser(input);
//            var arr = p.SplitOnOperand();
//            CollectionAssert.AreEqual(Stack.ReplaceConstsandStringsWithIntValues(arr), new int[] { 3, 4 });
//        }


//        // x = 7
//        [TestMethod]
//        public void StackAddsKeyValuePairs()
//        {
//            var input = "x=2";
//            var p = new Parser(input);
//            var arr = p.SplitOnOperand();
//            p.AddKeyValuePair(arr);
//            Assert.AreEqual(Stack.Constants[arr[0]], 2);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void StackCantChangeValueofConstant()
//        {
//            var input = "b=2";
//            var p = new Parser(input);
//            var arr = p.SplitOnOperand();
//            p.AddKeyValuePair(arr);
//            var input2 = "b=3";
//            var p2 = new Parser(input2);
//            var arr2 = p.SplitOnOperand();
//            p.AddKeyValuePair(arr);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void variablesCanOnlyBeOneCharacter()
//        {
//            var input = "cc=2";
//            var p = new Parser(input);
//            var arr = p.SplitOnOperand();
//            p.AddKeyValuePair(arr);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void variablesCantComeLastInAnExpression()
//        {
//            var input = "22=c";
//            var p = new Parser(input);
//            var arr = p.SplitOnOperand();
//            p.AddKeyValuePair(arr);
//        }

//        // a*7 or 3*r
//        [TestMethod]
//        public void GetsVariableValueFromStackDictionary()
//        {
//            var input1 = "a=10";
//            var input2 = "a*8";
//            var p = new Parser(input1);
//            var arr = p.SplitOnOperand();
//            p.AddKeyValuePair(arr);
//            var p2 = new Parser(input2);
//            var arr2 = p2.SplitOnOperand();
//            CollectionAssert.AreEqual(new int[] { 10, 8 }, Stack.ReplaceConstsandStringsWithIntValues(arr2));
//        }



//    }
//}
