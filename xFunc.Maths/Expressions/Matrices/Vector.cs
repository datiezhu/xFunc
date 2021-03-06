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
using System;
using System.Linq;
using xFunc.Maths.Analyzers;
using xFunc.Maths.Resources;

namespace xFunc.Maths.Expressions.Matrices
{

    /// <summary>
    /// Represents a vector.
    /// </summary>
    public class Vector : DifferentParametersExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="args">The values of vector.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="args"/> is null.</exception>
        public Vector(IExpression[] args) : base(args) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="size">The size of vector.</param>
        public Vector(int size) : base(new IExpression[size]) { }

        /// <summary>
        /// Gets or sets the <see cref="IExpression"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="IExpression"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The element of vector.</returns>
        public IExpression this[int index]
        {
            get
            {
                return m_arguments[index];
            }
            set
            {
                m_arguments[index] = value;
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode(3121, 8369);
        }

        private IExpression[] CalculateVector(ExpressionParameters parameters)
        {
            var args = new IExpression[this.ParametersCount];

            for (var i = 0; i < this.ParametersCount; i++)
            {
                if (m_arguments[i] == null)
                    continue;

                if (!(m_arguments[i] is Number))
                {
                    var result = m_arguments[i].Execute(parameters);
                    if (result is double doubleResult)
                        args[i] = new Number(doubleResult);
                    else
                        args[i] = new Number((int)result);
                }
                else
                {
                    args[i] = m_arguments[i];
                }
            }

            return args;
        }

        /// <summary>
        /// Executes this expression.
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the execution.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        /// <exception cref="System.NotSupportedException">Always.</exception>
        public override object Execute(ExpressionParameters parameters)
        {
            return new Vector(CalculateVector(parameters));
        }

        /// <summary>
        /// Analyzes the current expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="analyzer">The analyzer.</param>
        /// <returns>
        /// The analysis result.
        /// </returns>
        public override TResult Analyze<TResult>(IAnalyzer<TResult> analyzer)
        {
            return analyzer.Analyze(this);
        }

        /// <summary>
        /// Clones this instance of the <see cref="IExpression" />.
        /// </summary>
        /// <returns>
        /// Returns the new instance of <see cref="IExpression" /> that is a clone of this instance.
        /// </returns>
        public override IExpression Clone()
        {
            return new Vector(CloneArguments());
        }

        internal double[] ToCalculatedArray(ExpressionParameters parameters)
        {
            return (from exp in m_arguments.AsParallel().AsOrdered()
                    select (double)exp.Execute(parameters)).ToArray();
        }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public sealed override IExpression[] Arguments
        {
            get
            {
                return base.Arguments;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                if (value.Length == 0)
                    throw new ArgumentException(Resource.MatrixArgException, nameof(value));

                base.Arguments = value;
            }
        }

    }

}
