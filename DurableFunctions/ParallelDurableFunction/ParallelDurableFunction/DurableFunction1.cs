using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ParallelDurableFunction
{
    public static class DurableFunction1
    {
        [FunctionName("DurableFunction1")]
        public static async Task<IActionResult> Run(
            [OrchestrationTrigger] DurableOrchestrationContext ctx,
            ILogger log)
        {


            var msg = "Durable Function: ";
            var parallelTasks = new List<Task<string>>();
            Task<string> task1 = ctx.CallActivityAsync<string>("Function1", msg);
            parallelTasks.Add(task1);
            Task<string> task2 = ctx.CallActivityAsync<string>("Function2", msg);
            parallelTasks.Add(task2);
            Task<string> task3 = ctx.CallActivityAsync<string>("Function3", msg);
            parallelTasks.Add(task3);

            await Task.WhenAll(parallelTasks);

            // All 3 Activity functions finished
            msg = task1.Result + "\n\r" + task2.Result + "\n\r" + task3.Result;

            // Use LogWarning, so it shows up in Yelow, making it easier to spot
            log.LogWarning($"All 3 Activity functions completed for orchestragion {ctx.InstanceId}!");
            log.LogWarning(msg);

            return new OkObjectResult(msg);

        }
    }
}