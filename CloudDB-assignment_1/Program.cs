using Azure.Identity;
using CloudDB.Core.Extensions;
using CloudDB.Domain.Entities;
using CloudDB.Infrastructure;
using CloudDB.Infrastructure.Extensions;
using CloudDB.Infrastructure.Identity;
using CloudDB_assignment_1.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

var keyVaultName = builder.Configuration["KeyVaultName"];
if (!string.IsNullOrEmpty(keyVaultName))
{
    var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
    builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
}

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

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddCoreDI();
builder.Services.AddInfrastructureDI();

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloudDB API v1");
    c.RoutePrefix = string.Empty;
});

app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
