# AppointmentApp – Patient Appointment System with ASP.NET MVC

This project is a **Patient Appointment System** developed using the ASP.NET MVC architectural pattern. It allows patients to book appointments, doctors to manage them, and administrators to control users and system operations, all through a clean, multi-layered structure.

## 🎯 Project Objective

To design a user-friendly, functional, and manageable appointment system with distinct interfaces for patients, doctors, and administrators.

## 👥 User Roles & Features

### 🧑‍⚕️ Patient
- Register and log in
- Create new appointments
- View active and past appointments
- Update password

### 👨‍⚕️ Doctor
- Log in
- View their own appointments
- Cancel appointments
- Edit profile

### 🛡️ Administrator
- Manage all patient and doctor accounts (add, delete, update)
- View all appointments in the system
- Update administrator profile

## 🧱 Technologies Used

- ASP.NET MVC 5
- Entity Framework
- SQL Server
- ADO.NET
- Multi-layer architecture (UI, Business, Data Access, Entity)

## 📁 Project Structure

AppointmentApp/
│
├── BusinessLayer/ # Business logic
├── DataAccessLayer/ # Data access and operations
├── EntityLayer/ # Entity definitions
├── AppointmentApp/ # MVC Web Application (UI Layer)
├── AppDB/ # Database backup (.bak file)
└── AppointmentApp.sln # Visual Studio Solution file

## 🗄️ Database

A `.bak` file is provided to restore the database.

📂 Location: `AppDB/AppointmentDb.bak`

You can restore it using **SQL Server Management Studio (SSMS)**.

## 🚀 Getting Started

1. Open the `AppointmentApp.sln` file in **Visual Studio**.
2. Restore NuGet packages if needed.
3. Restore the database using the `.bak` file in SSMS.
4. Update the connection string in `web.config`.
5. Run the project.

## 📌 Notes

- This project is intended for academic and learning purposes.
- The system follows a clean separation of concerns with multi-layered structure.

## 📄 License

This project is shared for educational purposes only.
