using EmployeePaymentSystem.Application;
using EmployeePaymentSystem.Application.Services.Employee;
using EmployeePaymentSystem.Application.Services.Payment;
using EmployeePaymentSystem.Application.Services.Season;
using EmployeePaymentSystem.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MainDbContext>(
    option => option
                    .UseSqlServer(builder.Configuration.GetConnectionString("MainDbContext"))
                    .AddInterceptors(new SoftDeleteInterceptor()));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ISeasonService, SeasonService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
