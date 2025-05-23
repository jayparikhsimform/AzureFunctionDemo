using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionDemo
{
    public static class HttpTriggerDemo
    {
        [FunctionName("HttpTriggerDemo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest request,
            ILogger logger)
        {
            logger.LogInformation("Received a request for the HTTP trigger function.");

            // Extract the 'name' parameter from the query string
            string queryName = request.Query["name"];

            // Read the request body and deserialize it into a structured object
            string bodyContent = await new StreamReader(request.Body).ReadToEndAsync();
            var requestData = JsonConvert.DeserializeObject<RequestPayload>(bodyContent);

            // Determine the name to use based on query string or request body
            string name = !string.IsNullOrEmpty(queryName) ? queryName : requestData?.Name;

            // Create a response message based on the presence of a name
            string responseMessage = string.IsNullOrEmpty(name)
                ? "Welcome! Please provide your name in the query string or request body for a personalized greeting."
                : $"Hello, {name}! Your request was processed successfully.";

            return new OkObjectResult(responseMessage);
        }

        // Class to represent the structure of the request payload
        private class RequestPayload
        {
            public string Name { get; set; }
        }
    }
}
