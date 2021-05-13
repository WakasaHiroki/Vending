using System;

namespace Vending
{
    public sealed class Coin
    {
        public static readonly Coin Yen100 = new Coin(amount: 100);
        public static readonly Coin Yen500 = new Coin(amount: 500);

        private readonly int amount;

        private Coin(int amount)
        {
            if (amount != 100 && amount != 500)
            {
                throw new Exception("100円玉と500円玉のみ使用できます。");
            }

            this.amount = amount;
        }

        public bool Is(Coin coin)
        {
            return amount == coin.amount;
        }

        public int Amount()
        {
            return amount;
        }
    }
}
