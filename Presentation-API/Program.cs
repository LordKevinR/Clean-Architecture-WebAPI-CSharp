using Application.Interfaces;
using Application.UseCases.Pets;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using InterfaceAdapters.Data;
using InterfaceAdapters.DTOs;
using InterfaceAdapters.Mappers;
using InterfaceAdapters.Models;
using InterfaceAdapters.Presenters.PetDetail;
using InterfaceAdapters.Presenters.Pets;
using InterfaceAdapters.Repository;
using Microsoft.EntityFrameworkCore;
using Presentation_API.Endpoints.Pets;
using Presentation_API.Middlewares;
using Presentation_API.Validators;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//validators
builder.Services.AddValidatorsFromAssemblyContaining<PetValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


//dependencies
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=midb.db");
});

//interfaces
builder.Services.AddScoped<IRepository<Pet>, Repository>();
builder.Services.AddScoped<IPresenter<Pet, PetViewModel>, PetPresenter>();
builder.Services.AddScoped<IPresenter<Pet, PetDetailViewModel>, PetDetailPresenter>();
builder.Services.AddScoped<IMapper<PetCreationRequestDTO, Pet>, PetMapper>();


//use cases
builder.Services.AddScoped<GetPetUseCase<Pet, PetViewModel>>();
builder.Services.AddScoped<GetPetUseCase<Pet, PetDetailViewModel>>();
builder.Services.AddScoped<AddPetUseCase<PetCreationRequestDTO>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.MapGroup("/api/pets").MapPets();

app.Run();