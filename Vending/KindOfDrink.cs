using System;

namespace Vending
{
    public sealed class KindOfDrink : IComparable
    {
        public static readonly KindOfDrink COKE = new KindOfDrink(0);
        public static readonly KindOfDrink DIET_COKE = new KindOfDrink(1);
        public static readonly KindOfDrink TEA = new KindOfDrink(2);

        private readonly int _kind;

        private KindOfDrink(int kind)
        {
            _kind = kind;
        }

        public bool Is(KindOfDrink kindOfDrink)
        {
            return _kind == kindOfDrink._kind;
        }

        public int CompareTo(object other)
        {
            return _kind.CompareTo(((KindOfDrink)other)._kind);
        }
    }
}
