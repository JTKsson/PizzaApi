using CloudDB.Core.Extensions;
using CloudDB.Domain.Entities;
using CloudDB.Infrastructure;
using CloudDB.Infrastructure.Extensions;
using CloudDB.Infrastructure.Identity;
using CloudDB.Infrastructure.Interfaces;
using CloudDB.Infrastructure.Repos;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExtendedContext(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<ApplicationUserContext>()
.AddDefaultTokenProviders();

// Core Services
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IIngredientService, IngredientService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddCoreDI();

// Infrastructure Repositories
//builder.Services.AddScoped<IProductRepo, ProductRepo>();
//builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
//builder.Services.AddScoped<IIngredientRepo, IngredientRepo>();
//builder.Services.AddScoped<IOrderRepo, OrderRepo>();
//builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddInfrastructureDI();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
