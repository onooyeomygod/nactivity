﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sys.Workflow.Engine.Impl.Bpmn.Webservice
{
    public interface IServiceWebApiHttpProxy
    {
        HttpClient HttpClient { get; }

        Task GetAsync(string uri);
        Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken);
        Task PostAsync(string uri, object parameter);
        Task<T> PostAsync<T>(string uri, object parameter, CancellationToken cancellationToken);
    }
}