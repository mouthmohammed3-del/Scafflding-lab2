using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Data;
using Scaffoldinglab2.Models;
using Scaffoldinglab2.Repositories.Implementations;
using Scaffoldinglab2.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dblab2DbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("local")));
builder.Services.AddIdentity<SysUser,IdentityRole>().AddEntityFrameworkStores<dblab2DbContext>();

//=====================Repositories===============
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<ITeacherRepository,TeacherRepository>();
builder.Services.AddScoped<ISubjectRepository,SubjectRepository>();
builder.Services.AddScoped<IUnitOfwork, UnitOfwork>();
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
