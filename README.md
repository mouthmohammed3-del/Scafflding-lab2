# School management
🚀 ASP.NET Core MVC Full Project

📌 Overview

This project represents my first full learning journey in ASP.NET Core MVC.
It demonstrates building a complete web application using modern best practices and real-world architecture.

---

🧠 Features

- 🔐 Authentication (Register / Login / Logout)
- 🔑 Authorization (Roles: Admin / User)
- 📊 Full CRUD Operations
- 🧩 MVC Architecture
- 🗄️ Database with Entity Framework Core
- ⚙️ Dependency Injection
- 🔄 Async Programming

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

🔷 MVC Architecture

- Model → represents data (Database)
- View → UI (HTML + Razor)
- Controller → handles requests and logic

🔁 Flow:

1. User sends request
2. Controller receives it
3. Model processes data
4. View returns response

---

🧩 Scaffolding (Auto Code Generation)

📌 What is Scaffolding?

Automatically generates:

- Controllers
- Views (CRUD)

🚀 Steps:

1. Right click Controllers
2. Add → Controller
3. Choose:

MVC Controller with views, using Entity Framework

4. Select Model & DbContext

✅ Output:

- Controller + Full CRUD Views

---

🗄️ Migrations

📌 What is Migration?

Used to create/update database from Models.

🚀 Commands:

Add-Migration InitialCreate
Update-Database

---

🔄 After Model Change:

Add-Migration UpdateModel
Update-Database

---

🧱 Code First Approach

📌 Concept:

Write code first → Database generated automatically

---

🧩 Example:

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public DbSet<Student> Students { get; set; }

Add-Migration CreateStudent
Update-Database

---

🔐 Identity (Authentication)

Register:

await _userManager.CreateAsync(user, password);

---

Login:

await _signInManager.PasswordSignInAsync(username, password, rememberMe, false);

---

Logout:

await _signInManager.SignOutAsync();

---

🔑 Authorization (Roles)

Protect page:

[Authorize]

Admin only:

[Authorize(Roles = "Admin")]

---

⚙️ Redirect to Login:

Configured in:

options.LoginPath = "/Account/Login";

---

🧩 Repository Pattern

📌 Purpose:

- Separate data access from Controller

---

Example:

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task Add(T entity);
    void Delete(T entity);
}

---

🧩 Unit of Work

📌 Concept:

- Save multiple operations in one transaction

await _context.SaveChangesAsync();

---

⚙️ Dependency Injection

Lifetimes:

- Transient → new object every time
- Scoped → per request
- Singleton → one instance

---

🔄 Async Programming

Example:

await _context.Students.ToListAsync();

Why?

- Better performance
- Non-blocking

---

⚠️ Common Issues

- ❌ Register not working → check "result.Errors"
- ❌ Form not submitting → check button type
- ❌ Validation errors → use "ModelState"
- ❌ Migration error → check connection string

---

📚 What I Learned

- MVC Pattern
- Entity Framework Core
- Identity System
- Repository & Unit of Work
- Async / Await
- Authorization

---

🎯 Future Improvements

- Admin Dashboard
- REST API
- Angular Frontend
- UI Enhancements

---

👨‍💻 Author

Moath A-lyaari
Full Stack Developer (ASP.NET + Angular)

---

💬 Notes

This project is part of my journey to becoming a professional Full Stack Developer 🚀
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
