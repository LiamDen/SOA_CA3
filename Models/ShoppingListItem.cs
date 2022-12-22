namespace ShoppingitemApi.Models
{
    public class ShoppingitemItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        // Prevent overposting
        public string? Secret { get; set; }
    }

    namespace ShoppingitemApi.Models
    {
        public class ShoppingitemItemDTO
        {
            public long Id { get; set; }
            public string? Name { get; set; }
            public bool IsComplete { get; set; }
        }
    }
}