using Application.Interfaces;
using Application.UseCases.Pets;
using Application.UseCases.Sales;
using Application.UseCases.Users;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using InterfaceAdapters.Adapters;
using InterfaceAdapters.Data;
using InterfaceAdapters.DTOs.Pets;
using InterfaceAdapters.DTOs.Sales;
using InterfaceAdapters.DTOs.Users;
using InterfaceAdapters.ExternalServices;
using InterfaceAdapters.Mappers.Pets;
using InterfaceAdapters.Mappers.Sales;
using InterfaceAdapters.Presenters.PetDetail;
using InterfaceAdapters.Presenters.Pets;
using InterfaceAdapters.Repository.Pets;
using InterfaceAdapters.Repository.Sales;
using Microsoft.EntityFrameworkCore;
using Presentation_API.Endpoints.Pets;
using Presentation_API.Endpoints.Sales;
using Presentation_API.Endpoints.Users;
using Presentation_API.Middlewares;
using Presentation_API.Validators;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//validators
builder.Services.AddValidatorsFromAssemblyContaining<PetValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PetUpdateValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


//dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=midb.db");
});


//interfaces
builder.Services.AddScoped<IRepository<Pet>, PetRepository>();
builder.Services.AddScoped<IPresenter<Pet, PetViewModel>, PetPresenter>();
builder.Services.AddScoped<IPresenter<Pet, PetDetailViewModel>, PetDetailPresenter>();
builder.Services.AddScoped<ISinglePresenter<Pet, PetViewModel>, PetSinglePresenter>();
builder.Services.AddScoped<ISinglePresenter<Pet, PetDetailViewModel>, PetDetailSinglePresenter>();
builder.Services.AddScoped<IMapper<PetCreationRequestDTO, Pet>, PetMapper>();
builder.Services.AddScoped<IMapper<PetUpdateRequestDTO, Pet>, PetEditMapper>();
builder.Services.AddScoped<IExternalService<UserServiceDTO>, UserService>();
builder.Services.AddScoped<IExternalServiceAdapter<User>, UserExternalServiceAdapter>();
builder.Services.AddScoped<IMapper<SaleRequestDTO, Sale>, SaleMapper>();
builder.Services.AddScoped<IRepository<Sale>, SaleRepository>();


//use cases 
builder.Services.AddScoped<GetPetUseCase<Pet, PetViewModel>>();
builder.Services.AddScoped<GetPetUseCase<Pet, PetDetailViewModel>>();
builder.Services.AddScoped<GetSinglePetUseCase<Pet, PetViewModel>>();
builder.Services.AddScoped<GetSinglePetUseCase<Pet, PetDetailViewModel>>();
builder.Services.AddScoped<AddPetUseCase<PetCreationRequestDTO>>();
builder.Services.AddScoped<UpdatePetUseCase<PetUpdateRequestDTO>>();
builder.Services.AddScoped<DeletePetUseCase>();
builder.Services.AddScoped<GetUsersUseCase>();
builder.Services.AddScoped<GenerateSaleUseCase<SaleRequestDTO>>();
builder.Services.AddScoped<GetSaleUseCase>();


//httpClient service
builder.Services.AddHttpClient<IExternalService<UserServiceDTO>, UserService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["BaseUrlUsers"]);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<BadRequestExceptionMiddleware>();
app.UseMiddleware<NotFoundExceptionMiddleware>();

app.MapGroup("/api/pets").MapPets();
app.MapGroup("/api/users").MapUsers();
app.MapGroup("/api/sales").MapSales();

app.Run();