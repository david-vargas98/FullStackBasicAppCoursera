namespace ClientAppdotnet.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}