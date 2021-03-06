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
using System.Numerics;

namespace xFunc.Maths.Expressions.Trigonometric
{

    /// <summary>
    /// The base class for trigonomeric functions. This is an <c>abstract</c> class.
    /// </summary>
    /// <seealso cref="xFunc.Maths.Expressions.UnaryExpression" />
    public abstract class TrigonometricExpression : UnaryExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigonometricExpression"/> class.
        /// </summary>
        /// <param name="expression">The argument of function.</param>
        protected TrigonometricExpression(IExpression expression) : base(expression) { }

        /// <summary>
        /// Calculates this mathematical expression (using degree).
        /// </summary>
        /// <param name="degree">The calculation result of argument.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        protected abstract double ExecuteDergee(double degree);

        /// <summary>
        /// Calculates this mathematical expression (using radian).
        /// </summary>
        /// <param name="radian">The calculation result of argument.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        protected abstract double ExecuteRadian(double radian);

        /// <summary>
        /// Calculates this mathematical expression (using gradian).
        /// </summary>
        /// <param name="gradian">The calculation result of argument.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        protected abstract double ExecuteGradian(double gradian);

        /// <summary>
        /// Calculates the this mathematical expression (complex number).
        /// </summary>
        /// <param name="complex">The calculation result of argument.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        protected abstract Complex ExecuteComplex(Complex complex);

        /// <summary>
        /// Executes this expression.
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the calculation.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        public override object Execute(ExpressionParameters parameters)
        {
            var result = m_argument.Execute(parameters);
            if (result is Complex complex)
                return ExecuteComplex(complex);

            if (result is double number)
            {
                if (parameters == null || parameters.AngleMeasurement == AngleMeasurement.Degree)
                    return ExecuteDergee(number);
                if (parameters.AngleMeasurement == AngleMeasurement.Radian)
                    return ExecuteRadian(number);
                if (parameters.AngleMeasurement == AngleMeasurement.Gradian)
                    return ExecuteGradian(number);
            }

            throw new ResultIsNotSupportedException(this, result);
        }

    }

}
