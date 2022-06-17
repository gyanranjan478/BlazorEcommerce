namespace BlazorEcommerce.Server.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductstAsync();
        Task<ServiceResponse<Product>> GetProducttAsync(Guid id);
    }
}
