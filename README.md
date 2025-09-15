# HealtCheck

HealtCheck is a web application for managing healthcare appointments, doctors, clients, and organizations.

## Features

- Manage doctors, clients, clerks, and organizations
- Book and manage appointments
- Assign specializations to doctors
- Payment and refund management
- User authentication (login/register)
- Responsive Bootstrap-based UI

## Getting Started

### Prerequisites

- [.NET 7 SDK or later](https://dotnet.microsoft.com/download)
- SQL Server (or LocalDB for development)

### Setup

1. **Clone the repository:**

   ```
   git clone https://github.com/yourusername/HealtCheck.git
   cd HealtCheck
   ```

2. **Configure the database:**

   - Update the `appsettings.json` with your SQL Server connection string.

3. **Apply migrations and seed data:**

   ```
   dotnet ef database update
   ```

4. **Run the application:**

   ```
   dotnet run
   ```

5. **Open in browser:**
   - Navigate to `https://localhost:5001` or the URL shown in the console.

## Project Structure

- `Controllers/` - MVC controllers for each entity
- `Models/` - Entity models
- `Data/` - Entity Framework DbContext and data seeding
- `Views/` - Razor views for UI
- `wwwroot/` - Static files (CSS, JS, images)

## License

This project is licensed under the [MIT License](LICENSE).
