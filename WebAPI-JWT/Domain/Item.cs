namespace Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public float? Price100gr { get; set; }
        public float? PriceKg { get; set; }

        public Category Category { get; set; } = null!;
    }
}