namespace CloudDB.Domain.DTO
{
    public class ProductGetDTO
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }

    public class ProductCreateDTO
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public List<int> IngredientIds { get; set; }
    }
    public class ProductUpdateDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public  int? CategoryId { get; set; }
        public List<int>? IngredientIds { get; set; }
    }
}
