using EmployeeAPI.Profiles;
using EmployeeTest.Api.Data;
using EmployeeTest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AutoMapper and specify the profile(s) to use
builder.Services.AddAutoMapper(typeof(EmployeeProfile));

//Add SQL Server connection
builder.Services.AddDbContext<EmployeeDbContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add respositories injection
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
