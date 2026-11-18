# 🧱 .NET Clean API Starter

A minimal, well-structured ASP.NET Core 8 Web API starter kit — built to help developers skip the boilerplate and start shipping features faster. No database setup required: it runs immediately with an in-memory store, so you can clone it and have a working REST API in under a minute.

<br/>

## ✨ Features

🔹 Minimal hosting model (Program.cs, no Startup.cs)<br/>
🔹 Clean separation: Models / Repositories / Endpoints / Middleware<br/>
🔹 Swagger/OpenAPI enabled out of the box<br/>
🔹 Global exception handling middleware (consistent JSON error responses)<br/>
🔹 Dependency injection wired for easy testing and swapping implementations<br/>
🔹 In-memory repository (swap for EF Core / Dapper / Mongo when you're ready)<br/>
🔹 MIT licensed — use it in personal or commercial projects

<br/>

## 🚀 Getting started

```bash
git clone https://github.com/lenivalestevao/dotnet-clean-api-starter.git
cd dotnet-clean-api-starter/src
dotnet run
```

Then open `https://localhost:5001/swagger` to try the sample Tasks endpoints.

<br/>

## 📁 Project structure

```
src/
Program.cs                       # App bootstrap, DI, endpoint mapping
Models/TaskItem.cs                # Sample domain model
Repositories/TaskRepository.cs    # Interface + in-memory implementation
Middleware/ExceptionHandlingMiddleware.cs  # Global error handling
```

<br/>

## 🧩 Why this exists

Most "hello world" API templates either do too little (a single endpoint) or too much (a full enterprise architecture you have to rip apart). This starter aims for the middle: enough structure to grow a real project, nothing you have to delete on day one.

<br/>

## 🤝 Contributing

Issues and pull requests are welcome — this is meant to be a community starting point, not a one-off project.

<br/>

## 📄 License

MIT — see [LICENSE](LICENSE).
