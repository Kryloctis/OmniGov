
# OmniGov - Local Finance System

OmniGov is a comprehensive Local Finance System (LFS) designed for Local Government Units (LGUs). The project has been refactored into a modular Clean Architecture followed by industry standards.

## 🏗️ Project Structure

- **src/Apps/OmniGov.App**: The main WinForms desktop application.
- **src/Core/OmniGov.Core**: Shared foundational entities, interfaces, and core services like `GenericCommands`.
- **src/Modules/**: Functional business modules of the system.
  - **Accounting**: Accounting domain and data layers.
  - **Budget**: Budgeting domain and data layers.
  - **Treasury**: Treasury management domain and data layers.
  - **PropertyAssessment**: Real Property Tax (RPT) assessment layers (formerly RPT).
- **tests/**: Unit and integration tests for all layers.
- **docs/**: Project documentation, architectural decisions, and API specs.
- **scripts/**: Database migrations, seeds, and automation scripts.

## 🛠️ Build & Configuration

- **Directory.Build.props**: Centralized MSBuild properties (TargetFramework, RootNamespace, etc.).
- **Directory.Packages.props**: Centralized NuGet package version management.
- **global.json**: Pins the .NET SDK version for consistency across environments.

## 🚀 Getting Started

1. Open `OmniGov.sln` in Visual Studio 2022.
2. Ensure you have the .NET 8.0 SDK installed.
3. Update `servers.json` in `OmniGov.App` with your local database instances.
4. Build the solution.
