﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sys.Workflow.Bpmn.Models;
using Sys.Workflow.Cloud.Services.Api.Model;
using Sys.Workflow.Cloud.Services.Rest.Api;
using Sys.Workflow.Hateoas;
using Sys.Net.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sys.Workflow.Rest.Client.API
{
    /// <inheritdoc />
    class ProcessDefinitionClient : IProcessDefinitionController
    {
        private readonly IHttpClientProxy httpProxy;

        private static readonly string serviceUrl = WorkflowConstants.PROC_DEF_ROUTER_V1;

        /// <inheritdoc />
        public ProcessDefinitionClient(IHttpClientProxy httpProxy)
        {
            this.httpProxy = httpProxy;
        }

        /// <inheritdoc />
        public async Task<ActionResult<BpmnModel>> GetBpmnModel(string id)
        {
            HttpResponseMessage response = await httpProxy.GetAsync<HttpResponseMessage>($"{serviceUrl}/{id}/processmodel").ConfigureAwait(false);

            string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            BpmnModel model = JsonConvert.DeserializeObject<BpmnModel>(data, new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            ActionResult<BpmnModel> result = new ObjectResult(model);

            return result;
        }

        /// <inheritdoc />
        public async Task<ProcessDefinition> GetProcessDefinition(string id)
        {
            return await httpProxy.GetAsync<ProcessDefinition>($"{serviceUrl}/{id}").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<string> GetProcessDiagram(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<string> GetProcessModel(string id)
        {
            HttpResponseMessage response = await httpProxy.GetAsync<HttpResponseMessage>($"{serviceUrl}/{id}/processmodel").ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<string> GetProcessModel(ProcessDefinitionQuery query)
        {
            HttpResponseMessage response = await httpProxy.PostAsync<HttpResponseMessage>($"{serviceUrl}/processmodel", query).ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Resources<ProcessDefinition>> LatestProcessDefinitions(ProcessDefinitionQuery queryObj)
        {
            return await httpProxy.PostAsync<Resources<ProcessDefinition>>($"{serviceUrl}/latest", queryObj).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Resources<ProcessDefinition>> ProcessDefinitions(ProcessDefinitionQuery queryObj)
        {
            return await httpProxy.PostAsync<Resources<ProcessDefinition>>($"{serviceUrl}/list", queryObj).ConfigureAwait(false);
        }
    }
}
