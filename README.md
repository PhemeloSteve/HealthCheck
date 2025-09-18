# HealthCheck

HealthCheck is a modern hospital booking system web application. It allows patients to book appointments, view doctors, and manage their health records securely. The system supports role-based access for admins, doctors, clerks, and clients.

## Features

- Book and manage healthcare appointments
- Browse and view doctors by specialization
- Role-based dashboards for Admin, Doctor, Clerk, and Client
- Secure login and registration with minimalist black & white UI
- Manage doctors, clients, clerks, and organizations
- Payment and refund management
- Responsive, full-width layout with Bootstrap
- Privacy and security for health data

## Getting Started

### Prerequisites

- [.NET 9 SDK or later](https://dotnet.microsoft.com/download)
- SQL Server (or LocalDB for development)

### Setup

1. **Clone the repository:**

   ```
   git clone https://github.com/PhemeloSteve/HealthCheck.git
   cd HealthCheck
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

- `Controllers/` - MVC controllers for appointments, doctors, clients, clerks, and accounts
- `Models/` - Entity models for all system entities
- `Data/` - Entity Framework DbContext and migrations
- `Views/` - Razor views for all pages (Home, Login, Register, Appointments, Doctors, etc.)
- `wwwroot/` - Static files (CSS, JS, images)

## UI & Navigation

- Home page: Hospital booking system dashboard with creative, modern design
- Login/Register: Minimalist black & white Bootstrap styling
- Navigation: Role-based links; Appointments require login, Doctors page lists all doctors
- Full-width main content for immersive experience

## License

This project is licensed under the [MIT License](LICENSE).
