# Cookbook
A C# .NET Core web project. It allows users to register and login, post recipes of their favourite dish and leave comments. 
<br/>
<br/>

## Table of contents
0. [Project status](#Project-status)
1. [Description](#Description)
2. [Key features and functionalities](#Key-features-and-functionalities)
3. [Structure](#Structure)
4. [Installation instructions](#Installation-instructions)
5. [Dependencies](#Dependencies)
6. [System requirements](#System-requirements)
7. [Usage examples](#Usage-examples)
8. [API references](#API-references)
9. [Bugs](#Bugs)
10. [Future improvements](#Futute-improvements)
<br/>

## Project status
Completed and partially working. Not expecting changes.
<br/>
<br/>

## Description
The purpose and goal of the project is to create an MVC project with the application of some design patterns using C# and .NET . 

The intended audiences for the project are the teacher and assistant in my C# class and myself.
<br/>
<br/>

## Key features and functionalities
* ### KEY FEATURES
   * Users can browse recipes without an account but can't post recipes;
   * Users can register an account;
   * Users can login with a registered account;
   * Logged users can upload recipes;
   * Users can search recipes using the search and also apply filters;
   * User promotions (level of access). 

* ### FUNCTIONALITIES
   * Login and register system, provided by microsoft;
   * Custom user;
   * SQL Database model;
   * Search, Filtering, Pagination;
   * Comments;
   * Exception error handling;
   * DB mocking pattern and Seeded data;
<br/>

## Structutre
Here are some of the important directories and files you need to know about this project:
* `Cookbook.web` - The main project folder;
  * `Cookbook.web/Areas/Identity/Pages`- contains all user related frontend and program files;
  * `Cookbook.web/Controllers` - This is the folder with the object controllers;
  * `Cookbook.web/Properties/LaunchSettings.json`;
  * `Cookbook.web/Views` - Containg views for the objects;
  * `Cookbook.web/wwwroot` - Contains files for the frontend;
  * `Cookbook.web/appsettings.json`- Used to configure communication with the database;
  * `Cookbook.web/program.cs`- Used to configure the startup of the program;
* `Cookbook.Web.Models` - Contains all binding models and view models for the objects. Also contains relationship mapping in `Mapping` subfolder;
* `Cookbook.Infrastructure` - Contains files, related to seeding via the ApplicationDBContext, Database migration management, Repository configuration and Services configuration;
* `Cookbook.Common` - Contains global constant files for error checking and exception handling and helper functions for pagination;
* `Cookbook.Business` - Contains files for the implementation of the unit of work pattern in `Transactions` and the Services for objects;
* `Data.DataAccess`
  * `Data.DataAccess/EntityTypeConfigurations` - Object entity configuration files;
  * `Data.DataAccess/Migrations` - Contains database migrations;
  * `Data.DataAccess/Repositories` - Contains the repository files and interfaces for the objects;
  * `Data.DataAccess/Seeding` - Contains the files for seeding data upon program startup;
    * `Data.DataAccess/PartialSeeders` - Contains files for seeding objects;
  * `Data.DataAccess/ApplicationDBContext`- The file, responsible for configuring the ApplicationDBContext;
* `Data.DataModels`
  * `Data.DataModels/Abstraction` - Contains the base entity model;
  * `Data.DataModels/Entities` - Folder containing all entity files;
    * `Data.DataModels/Entities/Identity` - Contains the user identity files;
  * `Data.DataModels/Enums` - Contains the file for the user promotion states;
  * `Data.DataModels/Interfaces` - contains the interface for the base entity and `IAuditInfo.cs`.
<br/>

## Installation instructions
Usually, the project is supposed to be hosted on a server and given a domain. However, I don't have a HomeLab or am I able to rent a server or a domain. Instead:
1. Download this project;
2. Open the Project in Visual Studio 2022;
3. Open Miscrosoft SQL Server 2022;
4. Ensure you have all the needed dependencies;
5. Ensure you are connecting to your local database;
6. Build the project. You should have access now.
<br/>

## Dependencies
This is a list of dependencies that you need if you want to run the project locally. Aside from **an internet connection**, you will need:
* Visual Studio 2022;
* Microsoft SQL Server 2022;
* Microsoft .NET framework 6.X;
* NuGet packages:
  * `Data.DataModels`:
    * "Microsoft.AspNetCore.Http.Features" Version="5.0.17";
    * "Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.14";
  * `Data.DataAccess`:
    * "Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="6.0.14";
    * "Microsoft.EntityFrameworkCore.Design" Version="6.0.23";
    * "Microsoft.EntityFrameworkCore.Proxies" Version="6.0.23";
    * "Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.23";
    * "Microsoft.EntityFrameworkCore.Tools" Version="6.0.23";
    * "Microsoft.Extensions.Configuration.Json" Version="6.0.0";
    * "Microsoft.Extensions.Configuration.UserSecrets" Version="6.0.0";
  * `Cookbook.Web.Models`:
    * "Microsoft.AspNetCore.Http.Features" Version="5.0.17"
  * `Cookbook.web`:
    * "Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="6.0.14"
    * "Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.26"
    * "Microsoft.AspNetCore.Identity.UI" Version="6.0.26"
    * "Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.23"
    * "Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.26"
    * "Microsoft.EntityFrameworkCore.Tools" Version="6.0.26"
    * "Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="6.0.16"
  * `Cookbook.Infrastructure`:
    * "Microsoft.AspNetCore.Http.Abstractions" Version="2.2.0"
  * `Cookbook.Business`:
    * "Microsoft.AspNetCore.Hosting" Version="2.2.7"
<br/>

## System requirements
| System requirements  |
| -------------------- | 
| Microsoft Windows 10 | 
<br/>

## Usage examples
1. Make a tutorial on how the project can be used;
2. Use numbered lists;
<br>

## API references
* If the project is used as a standalone library, describe the functions that can be called;
<br/>

## Bugs
- [ ] describe any occuring bugs that need to be fixed;
<br/>

## Future improvements
- [ ] describe some ideas you would want to implement into your project;
<br>

## REQUIREMENTS
<ol>
   <li> Must be hosted on a VCS. Like GitHub, for example. </li>
   <ol>
      <li> Have at least 10 commits over 3 days </li>
   </ol>
</ol>

1. Implement ASP .NET Core Framework; <br>
   1.1. At least 10 views; <br>
   1.2. At least 5 independent entities with relations of type one-to-one / one-to-many / many to many; <br>
   1.3. At least 5 controllers; <br>
   1.4. At least full C.R.U.D. functionality for 3 entities.
2. Use Visual Studio Community 2022; <br>
3. Use Microsoft SQL server; <br>
4. Use Entity Framework Core for DB access; <br>
5. Use the standard ASP .NET Identity System to control users and roles; <br>
   5.1. At least 2 users - one with "NormalUser" role and the other with "Administrator" role. <br>
6. have error handling and data validation to avoid crashes. <br>
<br>

## RECOMMENDATIONS
1. Use the S.O.L.I.D. principles; <br>
2. have strong cohesion and loose coupling; <br>
3. Use naming conventions appropriate for C#; <br>
4. practice clean code; <br>
<br>

## EXTRAS
1. Seeding the DB with sample data; <br>
2. Use the repository-service pattern; <br>
3. Filtering information in the form of pagination, sorting and/or filtering by criteria; <br>
4. Logic separation in MVC Areas and partial views; <br>
5. others:
<ul>
   <ul>
      <li>Implement a bootstrap template;
      </li>
      <li>Do Unit testing;
      </li>
      <li>Do Integration testing;
      </li>
   </ul>
</ul>
<br>

## USED RESOURCES
<ul>
   <li>[GitHub markdown guide - basic syntax](https://github.com/mattcone/markdown-guide/blob/master/_basic-syntax/links.md)
   </li>
   <li>[how to use git with visual studio 2022](https://learn.microsoft.com/en-us/visualstudio/version-control/git-with-visual-studio?view=vs-2022)
   </li>
   <li>[Designing a Relational Database for a Cookbook](https://dev.to/amckean12/designing-a-relational-database-for-a-cookbook-4nj6)
   </li>
   <li>[Recipes Database](https://github.com/gadsone/sql6)
   </li>
   <li>[Many-to-Many relationsships](https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx)</li>
   <li>[One-to-Many relationsships](https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx)</li>
   <li>[One-to-One relationsships](https://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx)</li>
</ul>
