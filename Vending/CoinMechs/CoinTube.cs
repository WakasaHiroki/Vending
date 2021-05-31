namespace Vending.CoinMechs
{
    public sealed class CoinTube
    {
        private Quantity _quantity;
        private readonly Coin _coin;

        public CoinTube(Coin coin)
        {
            _quantity = new Quantity(0);
            _coin = coin;
        }

        public bool IsEmpty()
        {
            return _quantity.IsNone();
        }

        public void PutIn()
        {
            _quantity = _quantity.Add(new Quantity(1));
        }

        public Coin PutOut()
        {
            _quantity = _quantity.Subtract(new Quantity(1));
            return _coin;
        }

        public Quantity Quantity()
        {
            return _quantity;
        }
    }
}
