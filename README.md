# Scafflding-lab2
🚀 ASP.NET Core MVC Project

📌 Overview

This project is my first step in learning ASP.NET Core MVC with my instructor.
It demonstrates building a full-stack web application using:

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Identity
- Repository Pattern
- Unit of Work
- Authentication & Authorization

---

🧠 Features

🔐 Authentication

- User Registration (Sign Up)
- User Login
- User Logout

🔑 Authorization

- Role-based access control (Admin / User)
- Protect pages using "[Authorize]"

📊 CRUD Operations

- Create, Read, Update, Delete data
- Connected with SQL Server using Entity Framework Core

🧩 Architecture

- MVC Pattern (Model - View - Controller)
- Repository Pattern
- Unit of Work
- Dependency Injection

---

🛠️ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- C#
- Razor Views

---

⚙️ Project Structure

/Controllers
/Models
/Views
/Data
/Repositories

---

🔄 How It Works

1. User sends request from browser
2. Controller receives request
3. Controller interacts with Model / Repository
4. Data is processed using EF Core
5. View is returned to user

---

🔐 Identity Flow

Register:

- User enters data
- "UserManager.CreateAsync()" creates account
- Password is hashed and saved

Login:

- "SignInManager.PasswordSignInAsync()"
- If success → redirect to Home

Logout:

- "SignInManager.SignOutAsync()"

---

🧪 Common Issues I Faced

- ❌ Register not working → fixed by showing "result.Errors"
- ❌ Form not submitting → fixed button type
- ❌ Validation errors → solved using "ModelState"
- ❌ Authorization redirect → understanding "[Authorize]"

---

📚 What I Learned

- MVC Architecture
- Entity Framework Core
- Identity (Login/Register)
- Dependency Injection
- Repository Pattern
- Unit of Work
- Async / Await
- Authorization & Roles

---

🎯 Future Improvements

- Add Admin Dashboard
- Improve UI design
- Add API (RESTful)
- Connect with Angular (Frontend)

---

👨‍💻 Author

Moath A-lyaari
Full Stack Developer (ASP.NET + Angular)

---

💬 Notes

This project is part of my learning journey to become a professional Full Stack Developer. 🚀
