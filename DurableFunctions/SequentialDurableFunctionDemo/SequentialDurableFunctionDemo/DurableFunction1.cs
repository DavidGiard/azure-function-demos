using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SequentialDurableFunctionDemo
{
    public static class DurableFunction1
    {
        [FunctionName("DurableFunction1")]
        public static async Task<IActionResult> Run(
            [OrchestrationTrigger] DurableOrchestrationContext ctx,
            ILogger log)
        {
            var msg = "\n\rDurable Function: ";
            msg = await ctx.CallActivityAsync<string>("Function1", msg);
            msg = await ctx.CallActivityAsync<string>("Function2", msg);
            msg = await ctx.CallActivityAsync<string>("Function3", msg);

            // Use LogWarning, so it shows up in Yelow, making it easier to spot
            log.LogWarning(msg);

            return new OkObjectResult(msg);
        }
    }
}