using CSharpFunctionalExtensions;

namespace Pizza.API.Domain.Entities
{
    public class NutritionalValue : ValueObject
    {
        public double EnergyValue { get; private set; }

        public double Protein {  get; private set; }

        public double Fats { get; private set; }

        public double Carbonydrates { get; private set; }

        public NutritionalValue(
            double energyValue,
            double protein,
            double fats,
            double carbonydrates)
        {
            EnergyValue = energyValue;
            Protein = protein;
            Fats = fats;
            Carbonydrates = carbonydrates;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return EnergyValue;
            yield return Protein;
            yield return Fats;
            yield return Carbonydrates;
        }
    }
}
