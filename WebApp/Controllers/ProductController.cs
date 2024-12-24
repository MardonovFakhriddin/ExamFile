using Domain.Models;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) :ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetAllAsync(Product product)
    {
        var response = await productService.GetAllAsync(product);
        return response;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        var response = await productService.GetByIdAsync(id);
        return response;
    }

    [HttpPost]
    public async Task<Response<bool>> CreateAsync(Product product)
    {
        var response = await productService.CreateAsync(product);
        return response;
    }
    [HttpPut]
    public async Task<Response<bool>> UpdateAsync(Product product)
    {
        var response = await productService.UpdateAsync(product);
        return response;
    }
    [HttpDelete]
    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var response = await productService.DeleteAsync(id);
        return response;
    }

    [HttpGet("export")]
    public async Task<Response<string>> ExportAsync()
    {
        var response = await productService.ExportAsync();
        return response;
    }

    [HttpGet("import")]
    public async Task<Response<string>> ImportAsync()
    {
        var response = await productService.ImportAsync();
        return response;
    }

    [HttpPut("update-by-file")]
    public async Task<Response<string>> UpdateByFileAsync()
    {
        var response = await productService.UpdateByFileAsync();
        return response;
    }

}