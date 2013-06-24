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

namespace xFunc.Maths.Expressions
{

    /// <summary>
    /// Represents the Number operation.
    /// </summary>
    public class Number : IMathExpression
    {

        private IMathExpression parentMathExpression;
        private double number;

        /// <summary>
        /// Initializes a new instance of the <see cref="Number"/> class.
        /// </summary>
        /// <param name="number">A number.</param>
        public Number(double number)
        {
            this.number = number;
        }

        /// <summary>
        /// Defines an implicit conversion of a <see cref="Number"/> to a double value.
        /// </summary>
        /// <param name="number">The value to convert to a double.</param>
        /// <returns>An object that contains the value of the <paramref name="number"/> parameter.</returns>
        public static implicit operator double(Number number)
        {
            return number.Value;
        }

        /// <summary>
        /// Defines an implicit conversion of double to <see cref="Number"/>.
        /// </summary>
        /// <param name="number">The value to convert to <see cref="Number"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="number"/> parameter.</returns>
        public static implicit operator Number(double number)
        {
            return new Number(number);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            Number num = obj as Number;
            if (num == null)
                return false;

            return number == num.Value;
        }

        /// <summary>
        /// Converts this expression to the equivalent string.
        /// </summary>
        /// <returns>The string that represents this expression.</returns>
        public override string ToString()
        {
            return number.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a number. Don't use this method if your expression has variables.
        /// </summary>
        /// <returns>A result of the calculation.</returns>
        public double Calculate()
        {
            return number;
        }

        /// <summary>
        /// Returns a number. Don't use this method if your expression has variables.
        /// </summary>
        /// <param name="parameters">A collection of variables.</param>
        /// <returns>A result of the calculation.</returns>
        /// <seealso cref="MathParameterCollection"/>
        public double Calculate(MathParameterCollection parameters)
        {
            return number;
        }

        /// <summary>
        /// Returns a number. Don't use this method if your expression has variables.
        /// </summary>
        /// <param name="parameters">A collection of variables.</param>
        /// <param name="functions">A collection of functions.</param>
        /// <returns>A result of the calculation.</returns>
        /// <seealso cref="MathParameterCollection"/>
        /// <seealso cref="MathFunctionCollection"/>
        public double Calculate(MathParameterCollection parameters, MathFunctionCollection functions)
        {
            return number;
        }

        /// <summary>
        /// Calculates a derivative of the expression.
        /// </summary>
        /// <returns>Returns a derivative of the expression of several variables.</returns>
        /// <seealso cref="Variable"/>
        public IMathExpression Differentiate()
        {
            return new Number(0);
        }

        /// <summary>
        /// Calculates a derivative of the expression.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns>Returns a derivative of the expression of several variables.</returns>
        /// <seealso cref="Variable"/>
        public IMathExpression Differentiate(Variable variable)
        {
            return new Number(0);
        }

        /// <summary>
        /// Clones this instanse of the <see cref="Number"/> class.
        /// </summary>
        /// <returns>Returns the new instance of <see cref="IMathExpression"/> that is a clone of this instance.</returns>
        public IMathExpression Clone()
        {
            return new Number(number);
        }

        /// <summary>
        /// Gets or Sets a number.
        /// </summary>
        public double Value
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        /// <summary>
        /// Get or Set the parent expression.
        /// </summary>
        public IMathExpression Parent
        {
            get
            {
                return parentMathExpression;
            }
            set
            {
                parentMathExpression = value;
            }
        }

    }

}
