﻿using Newtonsoft.Json;
using Sys.Workflow.Services.Api.Commands;
using System;
using System.Collections.Generic;

/*
 * Copyright 2018 Alfresco, Inc. and/or its affiliates.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Sys.Workflow.Cloud.Services.Api.Commands
{

    /// <summary>
    /// 流程信号命令
    /// </summary>
    public class SignalCmd : ICommand
    {
        private readonly string id = "signalCmd";
        private string name;
        private WorkflowVariable inputVariables;


        /// <summary>
        /// 构造函数
        /// </summary>
        public SignalCmd()
        {
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inputVariables">变量</param>
        /// <param name="name">名称</param>
        //[JsonConstructor]
        public SignalCmd(
            [JsonProperty("Name")]string name,
            [JsonProperty("TenantId")]string tenantId,
            [JsonProperty("InputVariables")]WorkflowVariable inputVariables = null) : this()
        {
            this.name = name;
            this.inputVariables = inputVariables;
            this.TenantId = tenantId;
        }

        /// <summary>
        /// 命令id
        /// </summary>

        public virtual string Id
        {
            get => id;
        }

        /// <summary>
        /// 信号名称
        /// </summary>

        public virtual string Name
        {
            get
            {
                return name;
            }
            set => name = value;
        }

        /// <summary>
        /// 变量
        /// </summary>

        public virtual WorkflowVariable InputVariables
        {
            get
            {
                return inputVariables;
            }
            set => inputVariables = value;
        }

        public virtual string TenantId
        {
            get; set;
        }

        public virtual string ExecutionId
        {
            get; set;
        }

        public virtual string BusinessKey
        {
            get; set;
        }
    }
}