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
* Describe how the project files are arranged and what they mean;
  * Use bullet points and short sentences;
<br/>

## Installation instructions
1. How to access and/or setup the project;
2. Use a numbered list;
<br/>

## Dependencies
* Dependency 1;
* Dependency 2;
<br/>

## System requirements
| System requirements |
| ------------------- | 
| requirement 1       | 
| requirement 2       | 
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
