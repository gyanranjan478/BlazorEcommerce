namespace BlazorEcommerce.Server.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductstAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.ToListAsync(),
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProducttAsync(Guid id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                response.Success = true;
                response.Message = "Sorry, but this product does not exist";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }
    }
}
