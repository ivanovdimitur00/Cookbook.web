# Cookbook
A C# .NET Core web project. It allows users to register and login, post recipes of their favourite dish and leave comments. 
<br/>
<br/>

## Table of contents
0. [Project status](#Project-status)
1. [Description](#Description)
2. [Project requirements](#Project-requirements)
3. [Key features and functionalities](#Key-features-and-functionalities)
4. [Structure](#Structure)
5. [Installation instructions](#Installation-instructions)
6. [Dependencies](#Dependencies)
7. [System requirements](#System-requirements)
8. [Usage examples](#Usage-examples)
9. [API references](#API-references)
10. [Bugs](#Bugs)
11. [Future improvements](#Futute-improvements)
12. [Used resources](#Used-resources)
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

## Project requirements
The requirements for the project can be viewed in [this file](PROJECT_REQUIREMENTS.pdf)
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
We assume that the project has been accessed on the internet or has been run on a local instance. 
<br/>

1. For unregistered users:
  * They can look at recipes and search for them, but not edit;
  * They can register and/or login;
2. For logged-in users:
  * They can create their own recipes;
  * They can leave comments on recipes;
  * They can ask for a promotion;
  * They can search for recipes;
3. For Administrators:
<br>

## API references
Nothing to mention here.
<br/>
<br/>

## Bugs
- [ ] There is a problem with user registration. The application crashes;
- [ ] There is a problem with user login. The application remains running but the user is not logged in;
- [ ] The seeded data does not appear;
- [ ] No restrictions on the information that can be inputted upon creating a new recipe or other object.
<br/>

## Future improvements
- [ ] The database models is quite messy due to the lack of understanding about object hierarchies and relations. Needs a touch-up;
- [ ] Pick a domain for the website and a hosting solution;
- [ ] Implement a frontend for the website using Bootstrap or another framework. You can get a template from [this site](https://themewagon.com/);
- [ ] Implement Unit testing;
- [ ] Implement Integration testing;
- [ ] Implement pagination in the controllers of objects;
- [ ] Test Search and Filter options.
<br>

## Used resources
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
