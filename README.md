# Silhouette

A code generating and templating engine for generating C# bootstrap code for a clean architecture project.
Silhouette can be used to generate domain projects containing entities, enumerations, value objects, events and exceptions with appropriate base classes,
multiple types of presentation projects such as standalone APIs using Kestrel or AWS Lambda-based APIs, application project using MediatR with CQRS pattern for commands, queries,
multiple types of database projects such as file-based databases using RavenDB.

## Commands

The following commands are currently supported in the tool.

### Initialize

The ``init`` command initializes the solution and structure of domain, application, presentation and persistence projects with approapriate base classes and directories.

```
silhouette.exe init --name Foobar
```
Projects with below structure are created.

* Untitled
    - Backend.Api
        - Backend.Api.csproj
        - Endpoints
        - Global.cs
    - Backend.Api.Standalone
        - Backend.Api.Standalone.csproj
        - Endpoints
        - HomeEndpoint.cs
        - Global.cs
        - Program.cs
    - Backend.Database
        - Backend.Database.csproj
        - Repositories
        - Global.cs
    - Backend.Database.FileSystem
        - Backend.Database.FileSystem.csproj
        - Repositories
        - Global.cs
    - Backend.Domain
        - Backend.Domain.csproj
        - Entities
            - Entity.cs
        - Enumerations
            - Enumeration.cs
        - Events
            - Event.cs
        - Exceptions
            - Error.cs
        - Values
            - ValueObject.cs
        - Global.cs
    - Backend.Server
        - Backend.Server.csproj
        - Commands
        - Queries
        - Repositories
        - AssemblyMarker.cs
        - Global.cs
    - Untitled.sln