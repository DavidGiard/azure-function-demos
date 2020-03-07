using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ParallelDurableFunction
{
    public static class Function4
    {
        [FunctionName("Function4")]
        public static async Task<string> Run(
            [ActivityTrigger] string msg,
            ILogger log)
        {
            log.LogWarning("This is Function 4");
            int secondsDelay = new Random().Next(8, 12);
            await Task.Delay(1000);
            log.LogInformation("Function 4 completed");
            msg += "\n\rFunction 4";
            return msg;
        }
    }
}
