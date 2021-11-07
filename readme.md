# Learning OData with Microsoft ASP.NET Core OData and Microsoft OData Client

* OData is short for Open Data Protocol
* OData Version 1 was developed by Microsoft 20xx
* Current version 4 (or 4.01) supports REST principles and exchange payload via JSON

* Libraries used
  * [Microsoft.AspNetCore.OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/): OData service implementation
  * [Microsoft.OData.Client](https://www.nuget.org/packages/Microsoft.OData.Client/): OData client implementation
  * [Microsoft.EntityFrameworkCore.Sqlite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/): Database access via Entity Framework Core to a SQLite database file.


## Preparation

* Please make sure you configure the path to the database file in the `Startup.cs` or leave to 'C:\temp\world.db'. Hint: If you want to change the content in the SQLite file without installing any applications you could use [SQLite Online](https://sqliteonline.com/). A great offline SQLite tool is [SQLiteStudio](https://sqlitestudio.pl/). 
* Install the [OData Connected Service](https://marketplace.visualstudio.com/items?itemName=marketplace.ODataConnectedService) extension to generate or regenerate the code for the client.
* This project uses [SwitchStartupProject for VS 2019](https://marketplace.visualstudio.com/items?itemName=vs-publisher-141975.SwitchStartupProjectForVS2019) to start both applications in Visual Studio at the same time.
* To test the URL's you could also use the `insomnia-export.json` with the [Insomnia](https://insomnia.rest/) HTTP client (or API testing tool).


## OData Service Implementation

### Manual steps

* Create the project `ASP.NET Core WebApi` for `.NET Core 3.1` without HTTPS
* 
