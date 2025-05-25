using CloudDB.Domain.DTO;
using CloudDB.Domain.Entities;
using CloudDB.Infrastructure.Identity;
using CloudDB.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloudDB.Infrastructure.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationUserContext _context;

        public ProductRepo(ApplicationUserContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(ProductCreateDTO product)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == product.CategoryId);

            var ingredients = await _context.Ingredients
            .Where(i => product.IngredientIds.Contains(i.IngredientId))
            .ToListAsync();

            var productDto = new Product
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Category = category,
                Ingredients = ingredients
            };
            _context.Products.Add(productDto);
            _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductUpdateDTO product)
        {
            var existingProduct = await _context.Products
                .Include(p => p.Ingredients)
                .SingleOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (product.ProductName != null)
                existingProduct.ProductName = product.ProductName;

            if (product.ProductPrice.HasValue)
                existingProduct.ProductPrice = product.ProductPrice.Value;

            if (product.CategoryId.HasValue)
            {
                var category = await _context.Categories
                    .SingleOrDefaultAsync(c => c.CategoryId == product.CategoryId.Value);
                existingProduct.Category = category;
            }

            if (product.IngredientIds != null)
            {
                var newIngredients = await _context.Ingredients
                    .Where(i => product.IngredientIds.Contains(i.IngredientId))
                    .ToListAsync();
                existingProduct.Ingredients.Clear();
                foreach (var ingredient in newIngredients)
                    existingProduct.Ingredients.Add(ingredient);
            }

            await _context.SaveChangesAsync();
        }

    }
}
