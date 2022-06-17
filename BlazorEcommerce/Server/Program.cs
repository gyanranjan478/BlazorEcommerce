global using BlazorEcommerce.Server.Data;
global using BlazorEcommerce.Server.Services.Products;
global using BlazorEcommerce.Shared;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add Entityframework services
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Swagger setup
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Services
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();
// Swagger setup
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Swagger middleware
app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
