namespace Vending
{
    public sealed class CoinTube
    {
        private Quantity quantity;
        private readonly Coin coin;

        public CoinTube(Coin coin)
        {
            quantity = new Quantity(0);
            this.coin = coin;
        }

        public bool IsEmpty()
        {
            return quantity.IsNone();
        }

        public void PutIn()
        {
            quantity = quantity.Add(new Quantity(1));
        }

        public Coin PutOut()
        {
            quantity = quantity.Subtract(new Quantity(1));
            return coin;
        }

        public Quantity Quantity()
        {
            return quantity;
        }
    }
}
