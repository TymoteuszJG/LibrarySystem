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
using Microsoft.AspNetCore.Hosting;
using DataLibrary.Communication;
/*
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddTransient<IBooksRepository, BookRepository>();
builder.Services.AddTransient<IBorrowersRepository, BorrowersRepository>();
builder.Services.AddTransient<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddTransient<IStaffRepository, StaffRepository>();
builder.Services.AddSingleton<IBookAccessRepository, BookAccessRepository>();
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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(BookAccess)));
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
app.UseEndpoints(endpoints =>
{
  endpoints.MapHub<ChatHub>("/chatHub"); // <-- Add this line
  endpoints.MapControllers();
  // Other endpoints...
});

app.Run();

//public partial class Program { }


public partial class Program
{
  public static void Main(string[] args)
  {
    CreateHostBuilder(args).Build().Run();
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Program>();
          });
}
*/
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddTransient<IBooksRepository, BookRepository>();
builder.Services.AddTransient<IBorrowersRepository, BorrowersRepository>();
builder.Services.AddTransient<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddTransient<IStaffRepository, StaffRepository>();
builder.Services.AddSingleton<IBookAccessRepository, BookAccessRepository>();
builder.Services.AddTransient<ILendedRepository, LendedRepository>();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Books)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Authors)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Staff)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Borrowers)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Lended)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(BookAccess)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
  /*
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());*/
  app.UseCors(x => x
        .WithOrigins("https://localhost:4200") // Add your client origin(s)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
}

app.UseRouting(); // Add this line

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
endpoints.MapHub<ChatHub>("/chatHub");
endpoints.MapControllers();
// Other endpoints...
});

app.Run();

public partial class Program
{
  public static void Main(string[] args)
  {
    CreateHostBuilder(args).Build().Run();
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Program>();
          });
}
