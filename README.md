# REMWaste Test Automation Project

## Overview

This repository contains automated UI and API tests for the REMWaste application. The tests are implemented using .NET and cover key workflows including TODO item management in the UI and API endpoints validation.

---

## Features

- UI Automation tests for Todo functionality:  
  - Adding, editing, completing, and deleting TODO items  
- API Automation tests to validate backend endpoints  
- Continuous Integration configured with GitHub Actions  
---

## Technologies Used

- .NET 8.0  
- NUnit for test framework  
- FluentAssertions for expressive assertions  
- GitHub Actions for CI pipeline  
- (Optional) Code coverage tools like Coverlet (can be added)  

---

## How to Run the Tests

### Prerequisites

- .NET 8.0 SDK installed  
- Git installed  
- Clone this repository  

### Running Locally

1. Open terminal or command prompt in the solution directory.  
2. Restore dependencies:  
   ```bash
   dotnet restore
3. Build the project:
   ```bash
   dotnet build --configuration Release
4. Run tests:
   ```bash
   dotnet test --configuration Release
