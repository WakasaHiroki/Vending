using System.Collections.Generic;
using System.Linq;

namespace Vending.CoinMechs
{
    public sealed class Charge
    {
        private readonly List<Coin> _coins = new List<Coin>();

        public void PutIn(Coin coin)
        {
            _coins.Add(coin);
        }

        public void Clear()
        {
            _coins.Clear();
        }

        public int Amount()
        {
            return _coins.Sum(x => x.Amount());
        }
    }
}
