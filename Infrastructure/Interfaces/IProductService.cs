using Domain.Models;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<List<Product>>> GetAllAsync(Product product);
    Task<Response<Product>> GetByIdAsync(int id);
    Task<Response<bool>> CreateAsync(Product product);
    Task<Response<bool>> UpdateAsync( Product product);
    Task<Response<bool>> DeleteAsync(int id);
    Task<Response<string>> ExportAsync();
    Task<Response<string>> ImportAsync();
    Task<Response<string>> UpdateByFileAsync();
}