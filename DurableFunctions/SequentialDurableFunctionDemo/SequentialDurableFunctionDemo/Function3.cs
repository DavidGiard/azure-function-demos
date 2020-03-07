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
    public static class Function3
    {
        [FunctionName("Function3")]
        public static async Task<string> Run(
            [ActivityTrigger] string msg,
            ILogger log)
        {
            log.LogWarning("This is Function 3");

            await Task.Delay(5000);
            msg += "\n\rFunction3 done; ";
            return msg;
        }
    }
}
