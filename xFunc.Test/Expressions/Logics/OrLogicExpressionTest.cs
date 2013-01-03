﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xFunc.Library.Logics.Expressions;
using xFunc.Library.Logics;

namespace xFunc.Test.Expressions.Logics
{

    [TestClass]
    public class OrLogicExpressionTest
    {

        private LogicParser parser;

        [TestInitialize]
        public void TestInit()
        {
            parser = new LogicParser();
        }

        [TestMethod]
        public void CalculateTest()
        {
            ILogicExpression exp = parser.Parse("a | b");
            LogicParameterCollection parameters = new LogicParameterCollection();
            parameters.Add('a');
            parameters.Add('b');

            parameters['a'] = true;
            parameters['b'] = true;
            Assert.IsTrue(exp.Calculate(parameters));

            parameters['a'] = true;
            parameters['b'] = false;
            Assert.IsTrue(exp.Calculate(parameters));

            parameters['a'] = false;
            parameters['b'] = true;
            Assert.IsTrue(exp.Calculate(parameters));

            parameters['a'] = false;
            parameters['b'] = false;
            Assert.IsFalse(exp.Calculate(parameters));
        }

    }

}
