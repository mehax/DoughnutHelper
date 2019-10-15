# DoughnutHelper

This project is just for fun, and also as an example on how to develop a simple structure by using .NET Core and Angular as a fully-functional web app.

## Features
* Interact the scenario by answering the following questions and receiving questions (messages) for each step. This is requested for the user to enter his name
* A `stats` page that prints the overall diagram with all possible choices and answers
* The ability to see the entire flow of one user by their unique choices, just by selecting the user 

## Solution structure
The structure is built under 4 layers (starting from the most independent one):
* `Domain` Holds entities for database-persistence (EntityFramework)
* `Persistence` Handles database context (unit of work) and migrations
* `Application` The main logic built using commands and queries separation (`CQS`), basically this is a bridge between `Presentation` and `Persistence`
* `Presentation` (`WebUI`) Handles API calls and requests, and handles Angular ClientApp build

## Installation
Before building this project, make sure to have installed at least .NET Core 3.0, and NodeJS 12

Clone the repository:

```git clone https://github.com/mehaX/DoughnutHelper.git```

If you're using dotnet CLI, restore the packages:

```dotnet restore```

If you need to change the database connection string, you can update the field `DefaultConnection` under `appsettings.Development.json`.

 Then run the migrations:
```dotnet ef database update --project DoughnutHelper.Persistence --startup DoughnutHelper.WebUI```

Run the project by adding `DoughnutHelper.WebUI` as a startup project:
```dotnet run --project DoughnutHelper.WebUI```

## Demo link
[http://doughnut.mehax.info](http://doughnut.mehax.info)
