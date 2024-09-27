using Application.Interfaces;
using Application.UseCases.Pets;
using Domain.Entities;
using InterfaceAdapters.Data;
using InterfaceAdapters.DTOs;
using InterfaceAdapters.Mappers;
using InterfaceAdapters.Models;
using InterfaceAdapters.Presenters;
using InterfaceAdapters.Repository;
using Microsoft.EntityFrameworkCore;
using Presentation_API.Endpoints.Pets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependencies
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=midb.db");
});

builder.Services.AddScoped<IRepository<Pet>, Repository>();
builder.Services.AddScoped<IPresenter<Pet, PetViewModel>, PetPresenter>();
builder.Services.AddScoped<IMapper<PetCreationRequestDTO, Pet>, PetMapper>();

builder.Services.AddScoped<GetPetUseCase<Pet, PetViewModel>>();
builder.Services.AddScoped<AddPetUseCase<PetCreationRequestDTO>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("/api/pets").MapPets();

app.Run();