using EntityDAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestsContext>(options =>
    options.UseSqlServer("Data Source=WINDOWS-05UFGJN;Initial Catalog=course;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"));

var app = builder.Build();


app.Run();


Console.WriteLine("Hello wrold");
