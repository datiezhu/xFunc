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
using System.Globalization;

namespace xFunc.Maths.Tokenization.Tokens
{

    /// <summary>
    /// Represents a number token.
    /// </summary>
    public class NumberToken : IToken
    {

        /// <summary>
        /// Initializes the <see cref="NumberToken"/> class.
        /// </summary>
        /// <param name="number">A number.</param>
        public NumberToken(double number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (typeof(NumberToken) != obj.GetType())
                return false;

            var token = (NumberToken)obj;

            return this.Number == token.Number;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Number: {Number.ToString(CultureInfo.InvariantCulture)}";
        }

        /// <summary>
        /// Gets a priority of current token.
        /// </summary>
        public int Priority => 101;

        /// <summary>
        /// Gets the number.
        /// </summary>
        public double Number { get; }

    }

}
