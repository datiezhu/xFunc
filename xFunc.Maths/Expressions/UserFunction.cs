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
using xFunc.Maths.Analyzers;
using xFunc.Maths.Expressions.Collections;

namespace xFunc.Maths.Expressions
{

    /// <summary>
    /// Represents user-defined functions.
    /// </summary>
    public class UserFunction : DifferentParametersExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFunction"/> class.
        /// </summary>
        /// <param name="function">The name of function.</param>
        /// <param name="args">Arguments.</param>
        public UserFunction(string function, IExpression[] args) : base(args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            this.Function = function;
            this.Arguments = args;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UserFunction exp && this.Function == exp.Function && this.ParametersCount == exp.ParametersCount)
                return true;

            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hash = 1721;

            hash = (hash * 5701) + Function.GetHashCode();
            hash = (hash * 5701) + ParametersCount.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Executes the user function.
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the execution.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <seealso cref="ExpressionParameters" />
        public override object Execute(ExpressionParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            var func = parameters.Functions.GetKeyByKey(this);

            var newParameters = new ParameterCollection(parameters.Variables.Collection);
            for (var i = 0; i < m_arguments.Length; i++)
            {
                var arg = func.Arguments[i] as Variable;
                newParameters[arg.Name] = (double)this.m_arguments[i].Execute(parameters);
            }

            var expParam = new ExpressionParameters(parameters.AngleMeasurement, newParameters, parameters.Functions);
            return parameters.Functions[this].Execute(expParam);
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
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns the new instance of <see cref="IExpression"/> that is a clone of this instance.</returns>
        public override IExpression Clone()
        {
            return new UserFunction(Function, m_arguments);
        }

        /// <summary>
        /// Gets the name of function.
        /// </summary>
        /// <value>The name of function.</value>
        public string Function { get; }

    }

}
