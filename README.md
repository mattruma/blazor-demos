# Overview

Demos related to Blazor and Maui.

* https://docs.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/maui?view=aspnetcore-6.0
* https://docs.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-6.0

## Projects

**BlazorApp1** - Blazor WASM application.

**MauiApp1** - Maui Blazor application.

**RazorClassLibrary1** - Shared components used by BlazorApp1 and MauiApp1.

## Features

* Share components between the Blazor and Maui applications.
* Read settings from `appsettings.json`. Easy for Blazor, but not so easy for Maui, have to embedded `appsettings.json` as a resource and load it in `MainProgram.cs`.
* Use `IConfiguration` in pages to display values.
* Call an external API using `HttpClient`, `HttpClientFactory` and a typed `HttpClient` using dependency injection.
* Call an external API inheriting from `ServiceBase` class.
* Call JavaScript from a class library.
* Use a third-party UI library, [Blazorise](https://blazorise.com/).
