using DataLibrary;
using DataLibrary.Commands;
using DataLibrary.Queries;
using DataLibrary.Models;
using DataLibrary.Repositories;
using DataLibrary.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBooksRepository, BookRepository>();
builder.Services.AddTransient<IBorrowersRepository, BorrowersRepository>();
builder.Services.AddTransient<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddTransient<IStaffRepository, StaffRepository>();
//builder.Services.AddTransient<ILendedRepository, LendedRepository>();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
//builder.Services.AddMediatR(typeof(GetAllBooks).GetTypeInfo().Assembly);
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Books)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Authors)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Staff)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Borrowers)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Lended)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
