﻿// Copyright 2012-2019 Dmitry Kischenko
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
// express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.Collections;
using xFunc.Maths.Expressions.LogicalAndBitwise;
using xFunc.Maths.Expressions.Programming;
using Xunit;

namespace xFunc.Tests.Expressions.Programming
{
    
    public class LessThanTest
    {

        [Fact]
        public void CalculateLessTrueTest()
        {
            var parameters = new ParameterCollection() { new Parameter("x", 0) };
            var lessThen = new LessThan(Variable.X, new Number(10));

            Assert.True((bool)lessThen.Execute(parameters));
        }

        [Fact]
        public void CalculateLessFalseTest()
        {
            var parameters = new ParameterCollection() { new Parameter("x", 10) };
            var lessThen = new LessThan(Variable.X, new Number(10));

            Assert.False((bool)lessThen.Execute(parameters));
        }

        [Fact]
        public void CalculateInvalidTypeTest()
        {
            var lessThen = new LessThan(new Bool(true), new Bool(true));

            Assert.Throws<ResultIsNotSupportedException>(() => lessThen.Execute());
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new LessThan(new Number(2), new Number(3));
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }

    }

}
