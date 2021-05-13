namespace Vending
{
    public class VendingMachine
    {
        private Stock stockOfCoke = new Stock(KindOfDrink.COKE); // コーラの在庫数
        private Stock stockOfDietCoke = new Stock(KindOfDrink.DIET_COKE); // ダイエットコーラの在庫数
        private Stock stockOfTea = new Stock(KindOfDrink.TEA); // お茶の在庫数
        private CoinTube cointubeOf100Yen = new CoinTube(Coin.Yen100); // 100円玉の在庫
        private CoinTube cointubeOf500Yen = new CoinTube(Coin.Yen500); // 500円玉の在庫
        //private List<Coin> change = new List<Coin>(); // お釣り
        private Charge charge = new Charge(); // 投入硬貨

        public VendingMachine()
        {
            // 在庫補充
            stockOfCoke.Replenish(new Quantity(5));
            stockOfDietCoke.Replenish(new Quantity(5));
            stockOfTea.Replenish(new Quantity(5));

            for (var i = 0; i < 10; i++)
            {
                cointubeOf100Yen.PutIn();
            }
        }

        /// <summary>
        /// ジュースを購入する。
        /// </summary>
        /// <param name="payment">投入金額。100円と500円のみ受け付ける</param>
        /// <param name="kindOfDrink">ジュースの種類。コーラ、ダイエットコーラ、お茶が指定できる。</param>
        /// <returns>指定したジュース。在庫不足や釣銭不足で変えなかった場合はnullが返される。</returns>
        public Drink Buy(Coin payment, KindOfDrink kindOfDrink)
        {
            charge.PutIn(payment);

            if (payment.Is(Coin.Yen100))
            {
                cointubeOf100Yen.PutIn();
            }
            if (payment.Is(Coin.Yen500))
            {
                cointubeOf500Yen.PutIn();
            }

            if (kindOfDrink.Is(KindOfDrink.COKE) && stockOfCoke.IsEmpty())
            {
                return null;
            }
            if (kindOfDrink.Is(KindOfDrink.DIET_COKE) && stockOfDietCoke.IsEmpty())
            {
                return null;
            }
            if (kindOfDrink.Is(KindOfDrink.TEA) && stockOfTea.IsEmpty())
            {
                return null;
            }

            // 釣銭不足
            if (payment.Is(Coin.Yen500) && cointubeOf100Yen.Quantity().LessThan(new Quantity(4)))
            {
                return null;
            }

            if (kindOfDrink == KindOfDrink.COKE)
            {
                return stockOfCoke.PutOut();
            }
            if (kindOfDrink == KindOfDrink.DIET_COKE)
            {
                return stockOfDietCoke.PutOut();
            }
            if (kindOfDrink == KindOfDrink.TEA)
            {
                return stockOfTea.PutOut();
            }

            return null;
        }

        /// <summary>
        /// お釣りを取り出す
        /// </summary>
        /// <returns>お釣り</returns>
        public Change Refund()
        {
            var change = new Change();

            var chargedAmount = charge.Amount();
            while (chargedAmount > 500 && !cointubeOf500Yen.IsEmpty())
            {
                chargedAmount -= 500;
                var coin = cointubeOf500Yen.PutOut();
                change.Add(coin);
            }

            while (chargedAmount > 100)
            {
                chargedAmount -= 100;
                var coin = cointubeOf100Yen.PutOut();
                change.Add(coin);
            }

            charge.Clear();
            return change;
        }
    }
}
