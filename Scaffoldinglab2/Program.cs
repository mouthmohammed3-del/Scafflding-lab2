using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dblab2DbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("local")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
