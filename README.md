# User Management System

## Overview
This User Management System is designed to manage user accounts within a Windows Form application using a database backend. It provides functionalities for creating new users, updating existing user information, deleting users, and viewing user details.

## Features
- **User Registration:** Register new users with details such as username, first name, last name, and password.
- **User Management:** Update user information including username, first name, last name, and password.
- **User Deletion:** Delete users from the system.
- **View User Details:** View detailed information about each user stored in the database.

## Technologies Used
- **Programming Language:** C#
- **Database:** SQL Server (or specify your preferred database system)
- **GUI Framework:** Windows Forms (WinForms)

## Installation
1. Clone the repository: `git clone https://github.com/your/repository.git`
2. Open the solution in Visual Studio.
3. Restore NuGet packages if necessary.
4. Configure your database connection in `App.config` or `Web.config`.
5. Build and run the application.

## Database Schema
The database schema includes the following tables:
```sql
CREATE TABLE Users (
    Username NVARCHAR(50) PRIMARY KEY,
    First_Name NVARCHAR(50) NOT NULL,
    Last_Name NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL
);
####Usage
Launch the application.
Use the provided interface to perform user management tasks:
Click Add User to register a new user.
Select a user from the list to update or delete their information.
Click Delete User to remove a user from the system.
Use Search or Filter options to find specific users.
Save changes to the database as needed.
##Authors
##M Zain Ul Abideen



