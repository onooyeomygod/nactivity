﻿using System;
using System.Collections.Generic;

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

namespace Sys.Workflow.Engine.Impl.EL
{

    using Sys.Workflow.Engine.Delegate;
    using Sys.Workflow.Engine.Impl.Persistence.Entity;

    /// <summary>
    /// Variable-scope only used to resolve variables when NO execution is active but expression-resolving is needed. This occurs eg. when start-form properties have default's defined. Even though
    /// variables are not available yet, expressions should be resolved anyway.
    /// 
    /// 
    /// 
    /// </summary>
    public class NoExecutionVariableScope : IVariableScope
    {

        private static readonly NoExecutionVariableScope INSTANCE = new NoExecutionVariableScope();

        /// <summary>
        /// Since a <seealso cref="NoExecutionVariableScope"/> has no state, it's safe to use the same instance to prevent too many useless instances created.
        /// </summary>
        public static NoExecutionVariableScope SharedInstance
        {
            get
            {
                return INSTANCE;
            }
        }

        public virtual IDictionary<string, object> Variables
        {
            get
            {
                return new Dictionary<string, object>();
            }
            set
            {
                throw new System.NotSupportedException("No execution active, no variables can be set");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual IDictionary<string, object> VariablesLocal
        {
            get
            {
                return new Dictionary<string, object>();
            }
            set
            {
                throw new System.NotSupportedException("No execution active, no variables can be set");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetVariables(IEnumerable<string> variableNames)
        {
            return new Dictionary<string, object>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetVariables(IEnumerable<string> variableNames, bool fetchAllVariables)
        {
            return new Dictionary<string, object>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetVariablesLocal(IEnumerable<string> variableNames)
        {
            return new Dictionary<string, object>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetVariablesLocal(IEnumerable<string> variableNames, bool fetchAllVariables)
        {
            return new Dictionary<string, object>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual object GetVariable(string variableName)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual object GetVariable(string variableName, bool fetchAllVariables)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual object GetVariableLocal(string variableName)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual object GetVariableLocal(string variableName, bool fetchAllVariables)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual T GetVariable<T>(string variableName)
        {
            return default;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual T GetVariableLocal<T>(string variableName)
        {
            return default;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual IDictionary<string, IVariableInstance> VariableInstances
        {
            get
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <returns></returns>
        public virtual IDictionary<string, IVariableInstance> GetVariableInstances(IEnumerable<string> variableNames)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual IDictionary<string, IVariableInstance> GetVariableInstances(IEnumerable<string> variableNames, bool fetchAllVariables)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual IDictionary<string, IVariableInstance> VariableInstancesLocal
        {
            get
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <returns></returns>
        public virtual IDictionary<string, IVariableInstance> GetVariableInstancesLocal(IEnumerable<string> variableNames)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual IDictionary<string, IVariableInstance> GetVariableInstancesLocal(IEnumerable<string> variableNames, bool fetchAllVariables)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual IVariableInstance GetVariableInstance(string variableName)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual IVariableInstance GetVariableInstance(string variableName, bool fetchAllVariables)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual IVariableInstance GetVariableInstanceLocal(string variableName)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual IVariableInstance GetVariableInstanceLocal(string variableName, bool fetchAllVariables)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual ISet<string> VariableNames
        {
            get
            {
                return new HashSet<string>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual ISet<string> VariableNamesLocal
        {
            get
            {
                return new HashSet<string>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        public virtual void SetVariable(string variableName, object value)
        {
            throw new System.NotSupportedException("No execution active, no variables can be set");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        /// <param name="fetchAllVariables"></param>
        public virtual void SetVariable(string variableName, object value, bool fetchAllVariables)
        {
            throw new System.NotSupportedException("No execution active, no variables can be set");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual object SetVariableLocal(string variableName, object value)
        {
            throw new System.NotSupportedException("No execution active, no variables can be set");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        /// <param name="fetchAllVariables"></param>
        /// <returns></returns>
        public virtual object SetVariableLocal(string variableName, object value, bool fetchAllVariables)
        {
            throw new System.NotSupportedException("No execution active, no variables can be set");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public virtual bool HasVariables()
        {
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool HasVariablesLocal()
        {
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual bool HasVariable(string variableName)
        {
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual bool HasVariableLocal(string variableName)
        {
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        public virtual void CreateVariableLocal(string variableName, object value)
        {
            throw new NotSupportedException("No execution active, no variables can be created");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="variables"></param>
        public virtual void CreateVariablesLocal<T1>(IDictionary<string, T1> variables)
        {
            throw new NotSupportedException("No execution active, no variables can be created");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        public virtual void RemoveVariable(string variableName)
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        public virtual void RemoveVariableLocal(string variableName)
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void RemoveVariables()
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void RemoveVariablesLocal()
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        public virtual void RemoveVariables(IEnumerable<string> variableNames)
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableNames"></param>
        public virtual void RemoveVariablesLocal(IEnumerable<string> variableNames)
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual IDictionary<string, object> TransientVariablesLocal
        {
            set
            {
                throw new NotSupportedException("No execution active, no variables can be set");
            }
            get
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        public virtual void SetTransientVariableLocal(string variableName, object variableValue)
        {
            throw new NotSupportedException("No execution active, no variables can be set");
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual IDictionary<string, object> TransientVariables
        {
            set
            {
                throw new NotSupportedException("No execution active, no variables can be set");
            }
            get
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        public virtual void SetTransientVariable(string variableName, object variableValue)
        {
            throw new NotSupportedException("No execution active, no variables can be set");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual object GetTransientVariableLocal(string variableName)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public virtual object GetTransientVariable(string variableName)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        public virtual void RemoveTransientVariableLocal(string variableName)
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void RemoveTransientVariablesLocal()
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        public virtual void RemoveTransientVariable(string variableName)
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void RemoveTransientVariables()
        {
            throw new NotSupportedException("No execution active, no variables can be removed");
        }
    }

}