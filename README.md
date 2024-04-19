# Torc.Challenge

## About the Project

The Torc.Challenge project is a basic CRUD application for a bookstore's book catalog. The backend is developed using .NET and C#, while the frontend is built with React. The database is managed through SQL Server.

## Technologies Used

- **Backend**: .NET + C#
- **Frontend**: React
- **Database**: SQL Server

## Features

- **Book Creation**: Allows adding new books to the catalog.
- **Book Reading**: Enables viewing all available books.
- **Book Updating**: Provides the option to edit book information.
- **Book Deletion**: Enables the removal of books from the system.

## How to Run

### Prerequisites

- .NET SDK
- Node.js
- A package manager like npm or yarn
- Docker: Ensure Docker is installed on your system to run a SQL Server container.

### Instructions

**1.** Clone the repository:

```bash
git clone https://github.com/leandrincamargo/Torc.Challenge.git
```

**2.** Navigate to the backend folder and restore the packages:

```bash
cd Torc.Challenge/Backend
dotnet restore
```

#### **3.** Setting Up the Database with Docker

**3.1.** Pull the SQL Server Docker image:

```bash
docker pull mcr.microsoft.com/mssql/server:2019-latest
```

**3.2.** Run the SQL Server container instance:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong(!)Password" -p 1433:1433 --name sql_server -h sql_server -d mcr.microsoft.com/mssql/server:2019-latest
```

Replace YourStrong(!)Password with a strong password of your choosing.

**3.3.** Ensure the SQL Server container is running:

```bash
docker ps
```

**3.4.** Execute the migrations to set up the database schema:

```bash
dotnet ef database update
```

Make sure to run this command inside the backend project directory where the Torc.Challenge.Infrastructure.csproj file is located.

**4.** Run the backend:

```bash
dotnet run
```

**5.** In a new terminal, navigate to the frontend folder and install the dependencies:

```bash
cd Torc.Challenge/Web
npm install
```

**6.** Start the frontend development server:

```bash
npm start
```

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

Leandro Veiga
