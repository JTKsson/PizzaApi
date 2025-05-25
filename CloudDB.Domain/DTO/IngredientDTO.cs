namespace CloudDB.Domain.DTO
{
    public class IngredientDTO
    {

        public class IngredientAddDTO
        {
            public string IngredientName { get; set; }
        }

        public class IngredientUpdateDTO
        {
            public int IngredientId { get; set; }
            public string IngredientName { get; set; }
        }
    }
}


