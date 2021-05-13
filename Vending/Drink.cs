namespace Vending
{
    public sealed class Drink
    {
        private readonly KindOfDrink kind;

        public Drink(KindOfDrink kind)
        {
            this.kind = kind;
        }

        public bool Is(KindOfDrink kind)
        {
            return this.kind.Is(kind);
        }
    }
}