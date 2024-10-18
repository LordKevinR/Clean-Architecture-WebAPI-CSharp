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
            builder.MapGet("/{id:int}", GetById);
            builder.MapGet("/search/{total:decimal}", GetbySearch);
            builder.MapDelete("/{id:int}", Delete);
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
        
        public static async Task<Ok<Sale>> GetById(int id, GetSingleSaleUseCase getSingleSaleUseCase)
        {
            var sale = await getSingleSaleUseCase.ExecuteAsync(id);
            return TypedResults.Ok(sale);
        }

        public static async Task<Ok<string>> Delete(int id, DeleteSaleUseCase deleteSaleUseCase)
        {
            await deleteSaleUseCase.ExecuteAsync(id);
            return TypedResults.Ok("Sale deleted successfuly");
        }

        public static async Task<Ok<IEnumerable<Sale>>> GetbySearch(decimal total, GetSaleSearchUseCase<SaleModel> getSaleSearchUseCase)
        {
            var sales = await getSaleSearchUseCase.ExecuteAsync(s => s.Total > total);
            return TypedResults.Ok(sales);
        }
    }
}
