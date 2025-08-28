# Klacks.Blazor

A Blazor Server application for Klacks password reset functionality.

## Features

- 🔐 **Password Reset Page** - Secure password reset with token validation
- 🎨 **Modern UI** - Bootstrap-based responsive design
- ⚡ **Real-time Validation** - Password strength indicator and validation
- 🔒 **Security** - Server-side token validation and API integration
- 🚀 **Blazor Server** - Interactive UI with SignalR

## Project Structure

```
Klacks.Blazor/
├── Components/        # Reusable Blazor components
├── Models/           # Data models and DTOs
├── Pages/            # Razor pages and Blazor pages
├── Services/         # API services and business logic
├── Shared/           # Shared layouts and components
└── wwwroot/          # Static files (CSS, JS, images)
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Running Klacks.Api instance (https://localhost:5001)

### Running the Application

1. **Restore packages:**
   ```bash
   dotnet restore
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

3. **Navigate to:** `https://localhost:7002`

### Configuration

Update `appsettings.json` to configure API endpoints:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:5001"
  }
}
```

## Usage

### Password Reset Flow

1. User receives email with reset link: `/reset-password?token=...`
2. Token is validated against Klacks.Api
3. User enters new password with real-time validation
4. Password is securely updated via API call

### Development

This is a **Blazor Server** application that demonstrates:

- **Component-based architecture** with reusable UI components
- **Dependency Injection** for services and HTTP clients  
- **Server-side rendering** with SignalR for interactivity
- **API Integration** with HttpClient and typed services
- **Form handling** with EditForm and validation
- **Real-time UI updates** with Blazor's reactive model

## API Dependencies

This application requires the following Klacks.Api endpoints:

- `POST /api/v1/backend/accounts/ResetPassword`
- `GET /api/v1/backend/accounts/ValidatePasswordResetToken`

## Contributing

1. Follow the existing code structure and naming conventions
2. Add appropriate error handling and validation
3. Update this README when adding new features

## Tech Stack

- **Framework:** Blazor Server (.NET 8.0)
- **UI:** Bootstrap 5 + Font Awesome
- **HTTP:** HttpClient with typed services
- **Validation:** Data Annotations + FluentValidation