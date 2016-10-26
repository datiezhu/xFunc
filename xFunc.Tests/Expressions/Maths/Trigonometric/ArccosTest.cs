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
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.ComplexNumbers;
using xFunc.Maths.Expressions.Trigonometric;
using Xunit;

namespace xFunc.Tests.Expressions.Maths.Trigonometric
{

    public class ArccosTest
    {

        [Fact]
        public void CalculateRadianTest()
        {
            var exp = new Arccos(new Number(1));

            Assert.Equal(Math.Acos(1), exp.Execute(AngleMeasurement.Radian));
        }

        [Fact]
        public void CalculateDegreeTest()
        {
            var exp = new Arccos(new Number(1));

            Assert.Equal(Math.Acos(1) / Math.PI * 180, exp.Execute(AngleMeasurement.Degree));
        }

        [Fact]
        public void CalculateGradianTest()
        {
            var exp = new Arccos(new Number(1));

            Assert.Equal(Math.Acos(1) / Math.PI * 200, exp.Execute(AngleMeasurement.Gradian));
        }

        [Fact]
        public void CalculateComplexNumberTest()
        {
            var complex = new Complex(3, 2);
            var exp = new Arccos(new ComplexNumber(complex));

            Assert.Equal(Complex.Acos(complex), exp.Execute());
            Assert.Equal(new Complex(0.60613782238729386, -1.9686379257930964), exp.Execute());
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new Arccos(new Number(1));
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }

    }

}
