﻿using System;

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
    using Sys.Workflow.Engine.Impl.Contexts;
    using Sys.Workflow.Engine.Impl.Delegate.Invocation;
    using Sys;

    /// <summary>
    /// Expression implementation backed by a JUEL <seealso cref="ValueExpression"/>.
    /// 
    /// 
    /// 
    /// </summary>
    [Serializable]
    public class JuelExpression : IExpression
    {
        /// <summary>
        /// 
        /// </summary>
        protected internal string expressionText;
        private readonly IValueExpression valueExpression;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueExpression"></param>
        /// <param name="expressionText"></param>
        public JuelExpression(IValueExpression valueExpression, string expressionText)
        {
            this.valueExpression = valueExpression;
            this.expressionText = expressionText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableScope"></param>
        /// <returns></returns>
        public virtual object GetValue(IVariableScope variableScope)
        {
            ELContext elContext = Context.ProcessEngineConfiguration.ExpressionManager.GetElContext(variableScope);
            try
            {
                ExpressionGetInvocation invocation = new ExpressionGetInvocation(valueExpression, elContext);
                Context.ProcessEngineConfiguration.DelegateInterceptor.HandleInvocation(invocation);
                return invocation.InvocationResult;
            }
            //catch (PropertyNotFoundException pnfe)
            //{
            //    throw new ActivitiException("Unknown property used in expression: " + expressionText, pnfe);
            //}
            //catch (MethodNotFoundException mnfe)
            //{
            //    throw new ActivitiException("Unknown method used in expression: " + expressionText, mnfe);
            //}
            //catch (ELException ele)
            //{
            //    throw new ActivitiException("Error while evaluating expression: " + expressionText, ele);
            //}
            catch (Exception e)
            {
                throw new ActivitiException("Error while evaluating expression: " + expressionText, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="variableScope"></param>
        public virtual void SetValue(object value, IVariableScope variableScope)
        {
            ELContext elContext = Context.ProcessEngineConfiguration.ExpressionManager.GetElContext(variableScope);
            try
            {
                ExpressionSetInvocation invocation = new ExpressionSetInvocation(valueExpression, elContext, value);
                Context.ProcessEngineConfiguration.DelegateInterceptor.HandleInvocation(invocation);
            }
            catch (Exception e)
            {
                throw new ActivitiException("Error while evaluating expression: " + expressionText, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return valueExpression?.ExpressionString ?? string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ExpressionText
        {
            get
            {
                return expressionText;
            }
        }
    }

}