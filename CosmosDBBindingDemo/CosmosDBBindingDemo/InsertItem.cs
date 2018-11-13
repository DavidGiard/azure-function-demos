using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace CosmosDBBindingDemo
{
    public static class InsertItem
    {
        [FunctionName("InsertItem")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequestMessage req,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection")]
            out ToDoItem document,
            ILogger log)
        {
            var content = req.Content;
            string jsonContent = content.ReadAsStringAsync().Result;
            document = JsonConvert.DeserializeObject<ToDoItem>(jsonContent);

            log.LogInformation($"C# Queue trigger function inserted one row");

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
