using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SequentialDurableFunctionDemo
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<string> Run(
            [ActivityTrigger] string msg,
            ILogger log)
        {
            log.LogWarning("This is Function 1");

            await Task.Delay(10000);
            msg += "\n\rFunction1 done; ";
            return msg;
        }
    }
}
