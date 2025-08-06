# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a **Blazor Server application** built with **.NET 8.0** that uses Interactive Server Components for real-time UI updates via SignalR. The project follows the modern Blazor component-based architecture introduced in .NET 8.

## Essential Development Commands

### Build and Run
```bash
# Build the project
dotnet build

# Run development server (hot reload enabled)
dotnet watch run

# Run without hot reload
dotnet run

# Run with HTTPS (port 7048)
dotnet run --launch-profile https
```

### Code Quality
```bash
# Format code
dotnet format

# Check formatting without fixing
dotnet format --check

# Build with warnings as errors
dotnet build -warnaserror
```

### Testing
```bash
# No test project exists yet. To add tests:
dotnet new xunit -n Nexus.Tests
dotnet sln add Nexus.Tests/Nexus.Tests.csproj
dotnet test
```

### Package Management
```bash
# Restore packages
dotnet restore

# Add a package
dotnet add package [PackageName]

# List packages
dotnet list package
```

## Architecture and Key Patterns

### Component Structure
```
/Components/
├── App.razor          → Root HTML document and script references
├── Routes.razor       → Router configuration with default layout
├── _Imports.razor     → Global using statements for all components
├── /Layout/          → Layout components
│   ├── MainLayout.razor → Main application layout
│   └── NavMenu.razor    → Navigation menu component
└── /Pages/           → Routable page components (@page directive)
```

### Rendering Modes
- **Static Server Rendering (SSR)**: Default for most pages
- **Interactive Server**: Add `@rendermode InteractiveServer` for interactive components
- **Streaming**: Add `@attribute [StreamRendering]` for progressive rendering

### Component Development Patterns
1. **Page components** go in `/Components/Pages/` with `@page` directive
2. **Shared components** go in `/Components/` (create subdirectories as needed)
3. **Component-scoped CSS**: Create `.razor.css` file with same name as component
4. **Dependency injection**: Register services in `Program.cs`, inject with `@inject`

### Service Registration (Program.cs)
```csharp
// Add custom services before builder.Build()
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddSingleton<ICacheService, CacheService>();
```

### State Management
Currently uses component-level state. For shared state across components:
1. Create a state service and register as Scoped/Singleton
2. Use Cascading Values for parent-child communication
3. Use EventCallback for child-to-parent communication

### Styling Approach
- Global styles: `/wwwroot/app.css`
- Bootstrap 5 included: Use Bootstrap classes
- Component styles: Create `ComponentName.razor.css` for isolation
- Isolated styles compile to `Nexus.styles.css` automatically

### Key Architectural Decisions
- **Blazor Server model**: All UI logic runs on server, updates via SignalR
- **No authentication**: Add with `builder.Services.AddAuthentication()` if needed
- **No data layer**: Add Entity Framework Core or API clients as needed
- **Antiforgery enabled**: For secure form submissions

### Development Tips
- Use `dotnet watch run` for hot reload during development
- Browser F12 tools to debug network traffic and JavaScript interop
- Server-side errors appear in terminal/console output
- For HTTPS cert issues: `dotnet dev-certs https --trust`