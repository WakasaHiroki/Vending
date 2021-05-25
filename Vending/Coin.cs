using System;

namespace Vending
{
    public sealed class Coin : IComparable
    {
        public static readonly Coin Yen100 = new Coin(amount: 100);
        public static readonly Coin Yen500 = new Coin(amount: 500);

        private readonly int _amount;

        private Coin(int amount)
        {
            if (amount != 100 && amount != 500)
            {
                throw new Exception("100円玉と500円玉のみ使用できます。");
            }

            _amount = amount;
        }

        public int Amount()
        {
            return _amount;
        }

        public int CompareTo(object other)
        {
            return _amount.CompareTo(((Coin)other)._amount);
        }
    }
}
