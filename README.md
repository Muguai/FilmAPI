# Assignment 3: FilmAPI

For this assignment we were to create a datastore and interface to store and manage movies, their characters and the movies franchises. The characters, movies and franschises follow business rules for 
the assignment which show how the entities relationship with each other. One movie can have many characters, a charachter can appear in many movies and a movie belongs to only one franchise but a 
franchise can contain many movies.

The database called FilmDb that we created stores information about moviecharacters, the movies they appear in, and the franchises the movies belong to. 
The FilmAPI project consists of an Entity Framework Code First workflow and an ASP.NET Core Web API in C#. The application consists of a database made in SQL Server through EF Core with a RESTful API. 
We integrated Swagger which was essential for testing the API and documentation, aswell as Docker to containurize the API (Docker Hub: https://hub.docker.com/repository/docker/muguai/filmapi/general)

We utilized pair programming for this assignment to practice efficient development. We started with creating the SQL database "FilmDb". In the database we added the tables necessary for the assignment.
After implementation of the tables we moved on to Visual Studio and worked with Swagger aswell to test the data. 

## Installation

To run the program make sure you have installed the following development environment and databasemanagement tools: \
• Visual Studio 2022 with .NET 6. \
• SQL Server Management Studio

## Authors

Fredrik Hammar: fredrik.hammar@se.experis.com https://github.com/Muguai \
Emma Hogstrand: emma.hogstrand@se.experis.com https://github.com/emmahogstrand
