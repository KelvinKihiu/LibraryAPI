# Book Library

## How to Run the Project

1. **Clone the Repository:**

2. **Modify the `appsettings.json` File:**
   Update the `MongoDb` connection string in the `appsettings.json` file to include your local server's connection string.

3. **Run the Project:**
   Navigate to the root directory of the project and run the following commands:

```bash
dotnet test
cd LibraryAPI
dotnet run
```

This will run the tests and then start the application.

Click the link for [Swagger](http://localhost:5089/swagger/index.html) which should contain basic documentation for the API, using OpenAPI standard. Change the port number if different.
