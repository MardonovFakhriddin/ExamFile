using Dapper;
using Domain.Models;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using static System.Net.HttpStatusCode;

namespace Infrastructure.Services;

public class ProductService(IContext context) : IProductService
{
    public async Task<Response<List<Product>>> GetAllAsync(Product product)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Products";
            var response = await context.Connection().QueryAsync<Product>(cmd);
            return new Response<List<Product>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM Products WHERE ProductId =@id";
            var response = await context.Connection().QuerySingleOrDefaultAsync<Product>(cmd, new { ProductId = id });
            if (response == null) return new Response<Product>(NotFound, "Product not found");
            return new Response<Product>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> CreateAsync(Product product)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO Products (Name,Description,Price,StockQuatntity,CategoryName,CreatedDate) values (@Name,@Description,@Price,@StockQuatntity,@CategoryName,@CreatedDate)";
            var response = await context.Connection().ExecuteAsync(cmd, product);
            if (response == 0)
                return new Response<bool>(InternalServerError, "Internal server error");
            return new Response<bool>(response > 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> UpdateAsync(Product product)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO Products (Name=@Name,Description=@Description,Price=@Price,StockQuatntity=@StockQuatntity,CategoryName=@CategoryName,CreatedDate=@CreatedDate)";
            var response = await context.Connection().ExecuteAsync(cmd, product);
            if (response == 0)
                return new Response<bool>(InternalServerError, "Internal server error");
            return new Response<bool>(response > 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<Response<bool>> DeleteAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "DELETE FROM Products WHERE ProductId = @id";
            var response = await context.Connection().ExecuteAsync(cmd, new { ProductId = id });
            if (response == 0) return new Response<bool>(NotFound, "Product not found");
            return new Response<bool>(response != 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

}