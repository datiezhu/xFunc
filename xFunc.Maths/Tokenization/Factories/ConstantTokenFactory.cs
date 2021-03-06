// Copyright 2012-2019 Dmitry Kischenko
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
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using xFunc.Maths.Resources;
using xFunc.Maths.Tokenization.Tokens;

namespace xFunc.Maths.Tokenization.Factories
{

    /// <summary>
    /// The factory which creates constant tokens.
    /// </summary>
    /// <seealso cref="xFunc.Maths.Tokenization.Factories.FactoryBase" />
    public class ConstantTokenFactory : FactoryBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantTokenFactory"/> class.
        /// </summary>
        public ConstantTokenFactory() : base(new Regex(@"\G(true|false)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) { }

        /// <summary>
        /// Creates the token.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <param name="tokens">The tokens.</param>
        /// <returns>
        /// The token.
        /// </returns>
        /// <exception cref="TokenizeException"></exception>
        protected override FactoryResult CreateTokenInternal(Match match, ReadOnlyCollection<IToken> tokens)
        {
            var result = new FactoryResult();
            var constant = match.Value.ToLower();

            if (constant == "true")
            {
                result.Token = new BooleanToken(true);
            }
            else if (constant == "false")
            {
                result.Token = new BooleanToken(false);
            }
            else
            {
                throw new TokenizeException(string.Format(Resource.NotSupportedSymbol, constant));
            }

            result.ProcessedLength = match.Length;
            return result;
        }

    }

}