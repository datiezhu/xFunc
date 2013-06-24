﻿// Copyright 2012-2013 Dmitry Kischenko
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

namespace xFunc.Maths.Expressions.Trigonometric
{

    public class Arctan : TrigonometryMathExpression
    {

        public Arctan() : base(null) { }

        public Arctan(IMathExpression firstMathExpression) : base(firstMathExpression) { }

        public Arctan(IMathExpression firstMathExpression, AngleMeasurement angleMeasurement) : base(firstMathExpression, angleMeasurement) { }

        /// <summary>
        /// Converts this expression to the equivalent string.
        /// </summary>
        /// <returns>The string that represents this expression.</returns>
        public override string ToString()
        {
            return ToString("arctan({0})");
        }

        public override double CalculateDergee(MathParameterCollection parameters, MathFunctionCollection functions)
        {
            var radian = firstMathExpression.Calculate(parameters, functions);

            return Math.Atan(radian) / Math.PI * 180;
        }

        public override double CalculateRadian(MathParameterCollection parameters, MathFunctionCollection functions)
        {
            return Math.Atan(firstMathExpression.Calculate(parameters, functions));
        }

        public override double CalculateGradian(MathParameterCollection parameters, MathFunctionCollection functions)
        {
            var radian = firstMathExpression.Calculate(parameters, functions);

            return Math.Atan(radian) / Math.PI * 200;
        }

        protected override IMathExpression _Differentiation(Variable variable)
        {
            Pow involution = new Pow(firstMathExpression.Clone(), new Number(2));
            Add add = new Add(new Number(1), involution);
            Div div = new Div(firstMathExpression.Clone().Differentiate(variable), add);

            return div;
        }

        public override IMathExpression Clone()
        {
            return new Arctan(firstMathExpression.Clone());
        }

    }

}
