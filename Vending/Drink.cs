namespace Vending
{
    public sealed class Drink
    {
        private readonly KindOfDrink _kind;

        public Drink(KindOfDrink kind)
        {
            _kind = kind;
        }

        public bool Is(KindOfDrink kind)
        {
            return _kind.Is(kind);
        }
    }
}