using Application.Interfaces;
using Application.UseCases.Sales;
using Domain.Entities;
using InterfaceAdapters.DTOs.Sales;
using InterfaceAdapters.Models.Sales;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation_API.Endpoints.Sales
{
    public static class SalesEndpoint
    {
        public static RouteGroupBuilder MapSales(this RouteGroupBuilder builder)
        {
            builder.MapPost("/", Create);
            builder.MapGet("/", GetAll);
            return builder;
        }

        public static async Task<Created> Create(SaleRequestDTO saleRequestDTO, GenerateSaleUseCase<SaleRequestDTO> saleUseCase)
        {
            await saleUseCase.ExecuteAsync(saleRequestDTO);
            return TypedResults.Created();
        }

        public static async Task<Ok<IEnumerable<Sale>>> GetAll(GetSaleUseCase getSaleUseCase)
        {
            var sales = await getSaleUseCase.ExecuteAsync();
            return TypedResults.Ok(sales);
        }
    }
}
