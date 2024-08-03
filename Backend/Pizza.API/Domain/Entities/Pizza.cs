using Pizza.API.Domain.Enums;

namespace Pizza.API.Domain.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty ;

        public double Radius { get; set; }

        public double Weight { get; set; }

        public decimal BasePrice { get; set; }

        public SizeType Sizetype { get; set; }

        public DoughType DoughType { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public NutritionalValue NutritionalValue { get; set; } = new NutritionalValue(0, 0, 0, 0);

        public List<Additive> Additives { get; set; } = new List<Additive>();
    }
}
