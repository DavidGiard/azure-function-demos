using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace CosmosDBBindingDemo
{
    public static class GetItemById
    {
        [FunctionName("GetItemById")]
            public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetItem/{id}")] HttpRequestMessage req,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection",
                Id = "{id}")
            ]ToDoItem toDoItem,
            ILogger log)
        {
            log.LogInformation($"Function triggered");

            if (toDoItem == null)
            {
                log.LogInformation($"Item not found");
                return new NotFoundObjectResult("Id not found in collection");
            }
            else
            {
                log.LogInformation($"Found ToDo item {toDoItem.Description}");
                return new OkObjectResult(toDoItem);
            }

        }
    }
}
