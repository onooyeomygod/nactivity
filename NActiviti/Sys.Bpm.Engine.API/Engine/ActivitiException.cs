﻿using System;
using System.Runtime.Serialization;

/* Licensed under the Apache License, Version 2.0 (the "License");
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
namespace Sys.Workflow.Engine
{
    /// <summary>
    /// Runtime exception that is the superclass of all Activiti exceptions.
    /// 
    /// 
    /// </summary>
    [Serializable]
    public class ActivitiException : Exception
    {
        private const long serialVersionUID = 1L;
        private string _code;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cause"></param>
        public ActivitiException(string message, Exception cause) : base(message, cause)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ActivitiException(string message) : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Code
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_code))
                {
                    return this.GetType().Name;
                }

                return _code;
            }
            set => _code = value;
        }

        protected ActivitiException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}