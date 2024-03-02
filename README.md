# SmartLocate.Admin

This project is a Blazor WebAssembly App that provides an interface for the Admin Users of the SmartLocate application to manage the application.

It is primarily a web application that uses C# and Razor syntax to provide an administration panel, that communicates with the backend microservices through the API Gateway.

## Prerequisites

- .NET 8.0 SDK
- Chromium browser that supports running WASM
- Already running microservices from the [SmartLocate.Backend](https://github.com/CloudMavericks/SmartLocate.Backend) repository

## Running the application

### Using Visual Studio or Rider

- Open the solution in Visual Studio or Rider
- Set the `SmartLocate.Admin` project as the startup project
- Run the application. You should have a new browser tab, that opens the application at http://localhost:6300/

### Using the command line

- Open the command line in the root of the repository
- Run the following command to build the application
  ```bash
  dotnet build src/SmartLocate.Admin.csproj
  ```
- Run the following command to run the application
  ```bash
  dotnet run --project src/SmartLocate.Admin.csproj
  ```
  
> **Note:** Ensure running the microservices from the [SmartLocate.Backend](https://github.com/CloudMavericks/SmartLocate.Backend) repository before running this project.