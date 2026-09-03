# Pokemon MVC App

A simple ASP.NET Core MVC web application that fetches Pokémon data from PokéAPI and lets users browse, search, and view details for individual Pokémon.[web:3192][web:3274]

## Purpose

This project was built to practice the ASP.NET Core MVC pattern and consuming an external Web API with .NET. ASP.NET Core MVC separates an application into Models, Views, and Controllers, where controllers handle requests and choose which view to render, while Razor views present the content to the user.[web:3192][web:2961]

## Features

- View a list of Pokémon from PokéAPI.[web:3274]
- Search for a Pokémon by name.[web:3274]
- Click a Pokémon to see details such as name, height, weight, base experience, type, and sprite image.[web:3274]
- Handle cases where a Pokémon is not found.[web:3274]
- Handle cases where the external API cannot be reached.[web:3274]

## Tech stack

- ASP.NET Core MVC for the web application structure and request handling.[web:3192]
- Razor Views for rendering HTML in `.cshtml` files.[web:2961]
- `HttpClient` for API communication, registered through ASP.NET Core dependency injection.[web:3293][web:3297]
- PokéAPI as the external read-only data source.[web:3274]

## Project structure

```text
Controllers/
  PokemonController.cs
Models/
  NamedApiResource.cs
  PokemonListResponse.cs
  PokemonDetails.cs
Services/
  IPokemonService.cs
  PokemonService.cs
Views/
  Pokemon/
    Index.cshtml
    Details.cshtml
    NotFound.cshtml
Program.cs
```

This structure follows the common ASP.NET Core MVC convention of keeping controllers, models, and views in separate folders, with views grouped by controller name.[web:3192][web:2961]

## How it works

When a user visits the app, the request goes to a controller action. The controller uses a separate service to call PokéAPI with `HttpClient`, maps the response JSON to C# models, and sends the data to a Razor view for rendering.[web:3192][web:3293][web:3274]

Example flow:

```text
Browser request
→ PokemonController
→ PokemonService
→ PokéAPI
→ C# models
→ Razor view
→ HTML response
```

## Endpoints used

- `GET https://pokeapi.co/api/v2/pokemon?limit=20` for the Pokémon list.[web:3274]
- `GET https://pokeapi.co/api/v2/pokemon/{name}` for Pokémon details and search.[web:3274]

## Dependency injection

The application registers MVC services, `HttpClient`, and the Pokémon service in `Program.cs`. ASP.NET Core supports constructor injection for controllers, which makes it easy to keep API logic in a separate service instead of placing it directly inside the controller.[web:3275][web:3297]

## Running the project

1. Clone the repository.
2. Open the solution in Visual Studio or VS Code.
3. Build and run the project.
4. Open the app in the browser.
5. Browse the Pokémon list or search by name.

## Notes

PokéAPI is a free public API that does not require authentication for these requests. The application does not use a local database for Pokémon data, because the assignment requires the information to be fetched directly from the external API.[web:3274]
