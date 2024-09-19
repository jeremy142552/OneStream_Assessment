# OneStream Assessment

This project consists of a WebAPI backend, Service Class Library Project, Tests and a Blazor Server frontend. The WebAPI invokes two other WebAPIs asynchronously, and the Blazor frontend interacts with this main WebAPI through the service class. A Unit Test project is also added to improve the project's reliability and maintainability.

## Project Structure

```
OneStream_Assessment/
├── OneStream_Assessment/             # Main solution folder
│   ├── OneStream_Assessment_WebAPI/         # Main WebAPI project
│   ├── OneStream_Assessment_BlazorWeb/  # Blazor Server frontend
│   └── OneStream_Assessment_Services/# Services project
├── .gitignore
├── OneStream_Assessment.sln
└── README.md                         # This file
```

## Setup Instructions

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 or later (recommended) or VS Code

### Steps to Run the Project

1. Clone the repository:
   ```
   git clone https://github.com/jeremy142552/OneStream_Assessment.git
   cd OneStream_Assessment
   ```

2. Open the solution in Visual Studio or your preferred IDE.

3. Restore NuGet packages for the solution.

4. Set multiple startup projects:
   - Right-click on the solution in Solution Explorer.
   - Select "Set Startup Projects".
   - Choose "Multiple startup projects".
   - Set "OneStream_Assessment_WebAPI" and "OneStream_Assessment_BlazorWeb" to "Start".

5. Press F5 or click "Start" to run the projects.

6. The Blazor frontend and a Swagger page should open in your default web browser automatically.

## Project Details

### OneStream_Assessment (Main WebAPI)

- Contains controllers for handling API requests.
- Implements asynchronous calls to simulated backend APIs.
- Endpoints:
  - GET /api/FrontEnd: Retrieves data from both simulated backend APIs asynchronously
  - POST /api/FrontEnd: Sends data to both simulated backend APIs asynchronously

### OneStream_Assessment_Blazor (Blazor Frontend)

- Provides a user interface to interact with the main WebAPI.
- Features:
  - Buttons to trigger GET requests to API1 and API2
  - Input field and buttons to send POST requests to API1 and API2
  - Display area to show the results from the API calls

### OneStream_Assessment_Services

- Contains the `FrontEndService` interface and implementation.
- Manages HTTP requests to the main WebAPI.

## Key Features

- Asynchronous API calls: The main WebAPI makes asynchronous calls to two simulated backend APIs.
- Error handling: Implemented throughout the application to manage and display errors appropriately.
- Dependency Injection: Utilized for managing services and promoting loose coupling.
- Blazor Server: Provides a responsive and interactive user interface.

## Testing

The project currently has a Unit Test project using xUnit to improve the project's reliability and maintainability.

## Additional Notes

- The project uses `IHttpClientFactory` for creating `HttpClient` instances, which is a best practice for managing HttpClient lifetimes.
- The Blazor frontend dynamically determines the server URL to support various deployment scenarios.
- CORS is not currently implemented, which may need to be addressed if the API and Blazor frontend are hosted separately.
