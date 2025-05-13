using CloudDB.Core.Interfaces;
using CloudDB.Core.Services;
using CloudDB.Infrastructure.Interfaces;
using CloudDB.Infrastructure.Repos;


var builder = WebApplication.CreateBuilder(args);

// Core Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Infrastructure Repositories
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IIngredientRepo, IngredientRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

var app = builder.Build();


app.Run();
