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
namespace Sys.Workflow.Engine.Impl.Bpmn.Parser.Handlers
{
    using Sys.Workflow.Bpmn.Models;

    /// 
    /// 
    public class CompensateEventDefinitionParseHandler : AbstractBpmnParseHandler<CompensateEventDefinition>
    {

        protected internal override Type HandledType
        {
            get
            {
                return typeof(CompensateEventDefinition);
            }
        }

        protected internal override void ExecuteParse(BpmnParse bpmnParse, CompensateEventDefinition eventDefinition)
        {

            if (bpmnParse.CurrentFlowElement is ThrowEvent throwEvent)
            {
                throwEvent.Behavior = bpmnParse.ActivityBehaviorFactory.CreateIntermediateThrowCompensationEventActivityBehavior(throwEvent, eventDefinition);

            }
            else if (bpmnParse.CurrentFlowElement is BoundaryEvent boundaryEvent)
            {
                boundaryEvent.Behavior = bpmnParse.ActivityBehaviorFactory.CreateBoundaryCompensateEventActivityBehavior(boundaryEvent, eventDefinition, boundaryEvent.CancelActivity);
            }
            else
            {

                // What to do?

            }
        }
    }
}