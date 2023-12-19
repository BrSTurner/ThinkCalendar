# ThinkLogic

An online calendar that allow users to create and manage events for the current month.

This project was built using .NET 7 

This project is following a few Design Patterns such as:

- Mediator
- Command
- Repository
- Unit Of Work
- Command Query Resposibility Segregation

Alongside best practices of software development and SOLID

It is monolitic ASP.NET Web application with layer segregation. 

A few frameworks were used to develop this projec, such as:

- Entity Framework to perform the Command operations in the database.
- Dapper to perform High Perfomance queries in the database.
- Fluent Validation to validate command fields.
- MediatR to implement the Mediator pattern

In order to run this project it is necessary to run the Update-Database command to perform the migrations to the Local DB.
