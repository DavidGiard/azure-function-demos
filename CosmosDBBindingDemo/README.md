# CosmosDB Binding Demos

A set of Azure functions that demonstrate how to bind a Function to Azure CosmosDB.

See [this article](http://davidgiard.com/2018/11/21/CosmosDBBindingInAzureFunctions.aspx) For a detailed explanation of each function.

## Functions

### InsertItem

Insert a document into a CosmosDB collection

### GetItems

Retrieve all documents from a CosmosDB collection

### GetItemById

Retreive a single document from a CosmosDB collection, given the document's ID

### GetCompleteItems

Retreive a set of document from a CosmosDB collection, based on a query

## Setup

To run this project, you must first 

1. Create a CosmosDB resource with the SQL API
2. Add a "ToDoList" database and "Items" collection to CosmosDb (You can do this from the CosmosDb "Quick start" blade)
3. Copy the CosmosDB connection string
4. Add a local.settings.json to this Visual Studio project, similar to the following:
    {
        "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "CosmosDBConnection": "ADD-CONNECTION-STRING-HERE",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
    }
    }
