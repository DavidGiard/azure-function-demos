using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ParallelDurableFunction
{
    public static class StarterFunction1
    {
        [FunctionName("StarterFunction1")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequestMessage req,
            [OrchestrationClient] DurableOrchestrationClient starter,
            TraceWriter log)
        {
            log.Info("About to start orchestration");

            var orchestrationId = await starter.StartNewAsync("DurableFunction1", log);
            return starter.CreateCheckStatusResponse(req, orchestrationId);
        }
    }
}
