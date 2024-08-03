using Pizza.API.Domain.Entities;
using Pizza.API.Domain.Enums;

namespace Pizza.API.Models.Pizza
{
    public class CreatePizza
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Radius { get; set; }

        public double Weight { get; set; }

        public decimal BasePrice { get; set; }

        public SizeType Sizetype { get; set; }

        public DoughType DoughType { get; set; }

        public IFormFile? Image { get; set; }

        public NutritionalValue NutritionalValue { get; set; } = new NutritionalValue(0, 0, 0, 0);

        public List<int> IdAdditives { get; set; } = new List<int>();
    }
}
