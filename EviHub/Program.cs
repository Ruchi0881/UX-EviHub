using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using EviHub.Data;
using EviHub.Services.Interfaces;
using EviHub.Services;
using EviHub.Repositories.Interfaces;
using EviHub.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
//builder.Services.AddScoped<ICertificationService, CertificationService>();
//builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<IDesignationService, DesignationService>();
//builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EviHubDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")));

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
