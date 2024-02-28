using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;
using Microsoft.OpenApi.Models;
using WebApiDemo.Repositories;
using WebApiDemo.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Angular Change start
builder.Services.AddCors(Options => Options.AddDefaultPolicy(
    builder =>builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    ));//end

var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));

// inject the services in Project
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<IEmployeeeRepository, EmployeeeRepository>();
builder.Services.AddScoped<IEmployeeeService, EmployeeeService>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiDemo", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
//angualr
app.UseCors();
//end
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDemo v1"));
app.Run();
