#region License

/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Globalization;

namespace Spring.Expressions.Processors
{
    /// <summary>
    /// Converts a string literal to a <see cref="DateTime"/> instance.
    /// </summary>
    /// <author>Erich Eichinger</author>
    public class IsNullValueConversionProcessor : IMethodCallProcessor
    {
        public object Process(object context, object[] args)
        {
            int argc = args != null ? args.Length : 0;
            switch (argc)
            {
                case 1:
                    return args[0];
                case 2:
                    return args[0] == null ? args[1] : args[0];
                default:
                    throw new ArgumentException("isnull(<value> [,<defaultValue>]) expects 1 or 2 arguments");
            }
        }
    }
}