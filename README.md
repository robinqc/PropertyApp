# PropertyApp

A modular .NET 9.0 web application, organized with clean architecture: separate projects for Domain, Application, Infrastructure, and API layers.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Git](https://git-scm.com/)
- [MongoDB](https://www.mongodb.com/docs/manual/installation/)
- (Optional) [Visual Studio Code](https://code.visualstudio.com/) with C# extension

## Getting Started

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd PropertyApp
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

### 3. Set Up Environment Variables

Copy `.env.example` (if present) as `.env`, or configure your environment variables as required for database connection, secrets, etc.

#### Example
Typical variables you may need:
- `ConnectionStrings__MongoDB` – your MongoDB connection string

### 4. Restore the MongoDB Database

Make sure MongoDB is installed and running. Then restore the database with:

```bash
mongorestore -d PropertyAppDB ./fixtures/PropertyAppDB/
```

This will import the sample data into a database named `PropertyAppDB`.

### 5. Run the Server

#### Development (Debug) Mode

```bash
dotnet run --project ./PropertyApp.Infrastructure.API
```

#### Production (Release) Mode

```bash
dotnet run --project ./PropertyApp.Infrastructure.API --configuration Release
```

### 6. Publish for Deployment

```bash
dotnet publish ./PropertyApp.Infrastructure.API --configuration Release --output ./publish
```
To run the published app:

```bash
dotnet ./publish/PropertyApp.Infrastructure.API.dll
```

---

## Project Structure

- `PropertyApp.Applications` – Application logic and services
- `PropertyApp.Domain` – Domain models and business rules
- `PropertyApp.Infrastructure.Data` – MongoDB context, repositories, and data access
- `PropertyApp.Infrastructure.API` – Entry point (Web API) for the application

---

## Troubleshooting

- Ensure MongoDB is installed, running, and accessible with your configured connection string.
- If data is missing, repeat the `mongorestore` step.
- For dependency issues, run `dotnet restore` again.

---

## Useful Commands

| Task                         | Command                                                                                 |
|------------------------------|-----------------------------------------------------------------------------------------|
| Restore packages             | `dotnet restore`                                                                        |
| Restore MongoDB database     | `mongorestore -d PropertyAppDB ./fixtures/PropertyAppDB/`                               |
| Run debug server             | `dotnet run --project ./PropertyApp.Infrastructure.API`                                 |
| Run production server        | `dotnet run --project ./PropertyApp.Infrastructure.API --configuration Release`         |
| Publish for deployment       | `dotnet publish ./PropertyApp.Infrastructure.API --configuration Release --output ./publish` |
| Run published app            | `dotnet ./publish/PropertyApp.Infrastructure.API.dll`                                   |

---