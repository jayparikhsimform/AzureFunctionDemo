# AzureFunctionDemo

This project demonstrates a simple Azure Function with an HTTP trigger using .NET 6.

## Features
- Accepts HTTP GET and POST requests
- Reads a `name` parameter from the query string or request body
- Returns a personalized greeting if a name is provided

## Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Azure Functions Core Tools](https://docs.microsoft.com/azure/azure-functions/functions-run-local)

## Getting Started

1. **Clone the repository**
   ```pwsh
   git clone <your-repo-url>
   cd AzureFunctionDemo
   ```

2. **Restore dependencies**
   ```pwsh
   dotnet restore
   ```

3. **Build the project**
   ```pwsh
   dotnet build
   ```

4. **Run the function locally**
   ```pwsh
   func start
   ```

## Usage

- **GET Request:**
  - `http://localhost:7071/api/HttpTriggerDemo?name=YourName`
- **POST Request:**
  - URL: `http://localhost:7071/api/HttpTriggerDemo`
  - Body: `{ "name": "YourName" }`

## Project Structure
- `HttpTriggerDemo.cs` - Main function code
- `host.json` - Azure Functions host configuration
- `local.settings.json` - Local settings (not for production)

## License
This project is for educational/demo purposes.
