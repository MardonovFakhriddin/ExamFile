using System.Net;
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

    public async Task<Response<string>> ExportAsync()
    {
        const string cmd = "select * from products";
        var products = await context.Connection().QueryAsync<Product>(cmd);
        const string path = "\"C:\\Users\\Fahriddin\\Desktop\\FileExam\\export.txt\"";
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        foreach (var product in products.ToList())
        {
            var txt =
                $"{product.ProductId},{product.Name}.{product.Description},{product.Price},{product.StockQuantity},{product.CategoryName},{product.CreatedDate}\n";
            await File.AppendAllTextAsync(path, txt);
        }
        return new Response<string>("Products exported successfully");

    }

    public async Task<Response<string>> ImportAsync()
    {
        const string path = "\"C:\\Users\\Fahriddin\\Desktop\\FileExam\\add.txt\"";
        if (File.Exists(path) == false)
        {
            return new Response<string>(HttpStatusCode.NotFound, "File not found");
        }
        var lines = await File.ReadAllLinesAsync(path);
        if (lines.Length == 0)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "File is empty");
        }
        var cnt = 0;
        foreach (var line in lines)
        {
            var lineSplit = line.Split(",");
            var product = new Product()
            {
                ProductId = int.Parse(lineSplit[0]),
                Name = lineSplit[1],
                Description = lineSplit[2],
                Price = decimal.Parse(lineSplit[3]),
                StockQuantity = int.Parse(lineSplit[4]),
                CategoryName = lineSplit[5],
                CreatedDate = DateTime.Parse(lineSplit[6])
            };
            const string cmd =
                "INSERT INTO Products (Name=@Name,Description=@Description,Price=@Price,StockQuatntity=@StockQuatntity,CategoryName=@CategoryName,CreatedDate=@CreatedDate)";
            var response = await context.Connection().ExecuteAsync(cmd, product);
            if (response == 0) continue;
            cnt++;
        }
        return new Response<string>($"{cnt} - products created successfully");
    }

    public async Task<Response<string>> UpdateByFileAsync()
    {
       const string path = "\"C:\\Users\\Fahriddin\\Desktop\\FileExam\\edit.txt\"";
       if (File.Exists(path) == false)
       {
           return new Response<string>(HttpStatusCode.NotFound, "File not found");
       }

       var lines = await File.ReadAllLinesAsync(path);
       if (lines.Length == 0)
       {
           return new Response<string>(HttpStatusCode.BadRequest, "File is empty");
       }
       var cnt = 0;
        foreach (var line in lines)
        {
            var lineSplit = line.Split(",");
            var product = new Product()
            {
                ProductId = int.Parse(lineSplit[0]),
                Name = lineSplit[1],
                Description = lineSplit[2],
                Price = decimal.Parse(lineSplit[3]),
                StockQuantity = int.Parse(lineSplit[4]),
                CategoryName = lineSplit[5],
                CreatedDate = DateTime.Parse(lineSplit[6])
            };
            var result = await UpdateAsync(product);
            if (result.StatusCode != 200) continue;
            cnt++;
        }
        return new Response<string>($"{cnt} - students updated successfully");
    }
}