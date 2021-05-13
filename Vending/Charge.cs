using System.Collections.Generic;
using System.Linq;

namespace Vending
{
    public sealed class Charge
    {
        private readonly List<Coin> coins = new List<Coin>();

        public void PutIn(Coin coin)
        {
            coins.Add(coin);
        }

        public void Clear()
        {
            coins.Clear();
        }

        public int Amount()
        {
            return coins.Sum(x => x.Amount());
        }
    }
}
