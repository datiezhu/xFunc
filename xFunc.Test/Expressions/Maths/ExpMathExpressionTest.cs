﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xFunc.Library.Maths;
using xFunc.Library.Maths.Expressions;

namespace xFunc.Test.Expressions.Maths
{

    [TestClass]
    public class ExpMathExpressionTest
    {

        private MathParser parser;

        [TestInitialize]
        public void TestInit()
        {
            parser = new MathParser();
        }

        [TestMethod]
        public void CalculateTest()
        {
            IMathExpression exp = parser.Parse("exp(2)");

            Assert.AreEqual(Math.Exp(2), exp.Calculate(null));
        }

        [TestMethod]
        public void DerivativeTest1()
        {
            IMathExpression exp = MathParser.Derivative(parser.Parse("exp(x)"));

            Assert.AreEqual("exp(x)", exp.ToString());
        }

        [TestMethod]
        public void DerivativeTest2()
        {
            IMathExpression exp = MathParser.Derivative(parser.Parse("exp(2x)"));

            Assert.AreEqual("2 * exp(2 * x)", exp.ToString());
        }

        [TestMethod]
        public void PartialDerivativeTest1()
        {
            IMathExpression exp = parser.Parse("deriv(exp(xy), x)").Derivative();
            Assert.AreEqual("y * exp(x * y)", exp.ToString());
        }

        [TestMethod]
        public void PartialDerivativeTest2()
        {
            IMathExpression exp = parser.Parse("deriv(exp(xy), y)").Derivative();
            Assert.AreEqual("x * exp(x * y)", exp.ToString());
        }

        [TestMethod]
        public void PartialDerivativeTest3()
        {
            IMathExpression exp = parser.Parse("deriv(exp(x), y)").Derivative();
            Assert.AreEqual("0", exp.ToString());
        }

        [TestMethod]
        public void ToStringTest()
        {
            IMathExpression exp = parser.Parse("exp(2)");

            Assert.AreEqual("exp(2)", exp.ToString());
        }

    }

}
