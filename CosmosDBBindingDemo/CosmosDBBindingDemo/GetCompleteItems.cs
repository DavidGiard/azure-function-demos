using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CosmosDBBindingDemo
{
    public static class GetCompleteItems
    {
        [FunctionName("GetCompleteItems")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection",
                SqlQuery = "select * from Items i where i.isComplete")
            ]IEnumerable<ToDoItem> toDoItems,
            ILogger log)
        {
            log.LogInformation($"Function triggered");

            if (toDoItems == null)
            {
                log.LogInformation($"No complete Todo items found");
            }
            else
            {
                var ltodoitems = (List<ToDoItem>)toDoItems;
                if (ltodoitems.Count == 0)
                {
                    log.LogInformation($"No complete Todo items found");
                }
                else
                {
                    log.LogInformation($"{ltodoitems.Count} Todo items found");
                }
            }

            return new OkObjectResult(toDoItems);
        }
    }
}
