using AutoMapper;
using DapperDAL.Repositories;
using DapperDAL.Repositories.Interfaces;
using EntityBLL.Configuration;
using EntityBLL.Interfaces.Services;
using EntityBLL.Services;
using EntityDAL.Data;
using EntityDAL.Data.Repositories;
using EntityDAL.Interfaces;
using EntityDAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product API",
        Description = "An ASP.NET Core Web API for managing Product-Category items",
    });
});

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true);


builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("MSSQLConnection")));


builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});


builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IUnitOfWorkDapper, UnitOfWorkDapper>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddDbContext<TestsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));


builder.Services.AddScoped<ITestModelRepository, TestModelRepository>();
builder.Services.AddScoped<ITestQuestionRepository, TestQuestionRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITestQuestionService, TestQuestionService>();


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
