using System.Collections.Generic;
using System.Linq;

namespace Vending
{
    public sealed class Change
    {
        private readonly List<Coin> coins = new List<Coin>();

        public void Add(Coin coin)
        {
            coins.Add(coin);
        }

        public int Amount()
        {
            return coins.Sum(x => x.Amount());
        }
    }
}
