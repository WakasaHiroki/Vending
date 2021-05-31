using System.Collections.Generic;
using System.Linq;

namespace Vending.CoinMechs
{
    public sealed class Change
    {
        private readonly List<Coin> _coins = new List<Coin>();

        public void Add(Coin coin)
        {
            _coins.Add(coin);
        }

        public int Amount()
        {
            return _coins.Sum(x => x.Amount());
        }
    }
}
