using Newtonsoft.Json;

namespace CosmosDBBindingDemo
{
    public class ToDoItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isComplete")]
        public bool IsComplete { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

    }
}
