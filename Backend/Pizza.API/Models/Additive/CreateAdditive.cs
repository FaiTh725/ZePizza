namespace Pizza.API.Models.Additive
{
    public class CreateAdditive
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public IFormFile? Image { get; set; }
    }
}
