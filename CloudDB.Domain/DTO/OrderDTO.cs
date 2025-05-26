namespace CloudDB.Domain.DTO
{
    public class OrderDTO
    {

        public class OrderCreateDTO
        {
            public List<int> ProductIds { get; set; } = new List<int>();
        }

        public class OrderGetDTO
        {
            public int TotalPrice { get; set; } 
            public ICollection<ProductGetDTO> Products { get; set; } = new List<ProductGetDTO>();
        }

    }
}
