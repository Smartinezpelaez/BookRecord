using BookRecord.DAL.Models;
using Microsoft.EntityFrameworkCore;
using BookRecord.BLL.Repository;
using BookRecord.BLL.Repository.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BookRecordContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CnBookRecord")));

// Add AutoMapper Injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add Repository
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
