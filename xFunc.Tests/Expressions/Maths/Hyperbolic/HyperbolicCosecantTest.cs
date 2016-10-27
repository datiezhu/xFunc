﻿// Copyright 2012-2016 Dmitry Kischenko
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
using System;
using System.Numerics;
using xFunc.Maths;
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.ComplexNumbers;
using xFunc.Maths.Expressions.Hyperbolic;
using Xunit;

namespace xFunc.Tests.Expressions.Maths.Hyperbolic
{
    
    public class HyperbolicCosecantTest
    {

        [Fact]
        public void ExecuteTest()
        {
            var exp = new Csch(new Number(1));

            Assert.Equal(MathExtensions.Csch(1), exp.Execute());
        }

        [Fact]
        public void ExecuteComplexNumberTest()
        {
            var complex = new Complex(3, 2);
            var exp = new Csch(new ComplexNumber(complex));

            Assert.Equal(ComplexExtensions.Csch(complex), exp.Execute());
            Assert.Equal(new Complex(-0.041200986288574125, -0.090473209753207426), exp.Execute());
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new Csch(new Number(1));
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }

    }

}
