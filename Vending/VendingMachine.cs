using System.Collections.Generic;
using System.Linq;

namespace Vending
{
    public class VendingMachine
    {
        private List<Drink> stockOfCoke = new List<Drink>(); // コーラの在庫数
        private List<Drink> stockOfDietCoke = new List<Drink>(); // ダイエットコーラの在庫数
        private List<Drink> stockOfTea = new List<Drink>(); // お茶の在庫数
        private List<Coin> stockOf100Yen = new List<Coin>(); // 100円玉の在庫
        private List<Coin> stockOf500Yen = new List<Coin>(); // 500円玉の在庫
        private List<Coin> change = new List<Coin>(); // お釣り

        public VendingMachine()
        {
            for (var i = 0; i < 5; i++)
            {
                stockOfCoke.Add(new Drink(KindOfDrink.COKE));
            }
            for (var i = 0; i < 5; i++)
            {
                stockOfDietCoke.Add(new Drink(KindOfDrink.DIET_COKE));
            }
            for (var i = 0; i < 5; i++)
            {
                stockOfTea.Add(new Drink(KindOfDrink.TEA));
            }
            for (var i = 0; i < 10; i++)
            {
                stockOf100Yen.Add(Coin.Yen100);
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
            change.Add(payment);

            if (kindOfDrink.Is(KindOfDrink.COKE) && stockOfCoke.Count == 0)
            {
                return null;
            }
            if (kindOfDrink.Is(KindOfDrink.DIET_COKE) && stockOfDietCoke.Count == 0)
            {
                return null;
            }
            if (kindOfDrink.Is(KindOfDrink.TEA) && stockOfTea.Count == 0)
            {
                return null;
            }

            // 釣銭不足
            if (payment.Is(Coin.Yen500) && stockOf100Yen.Count < 4)
            {
                return null;
            }

            if (payment.Is(Coin.Yen100))
            {
                // 100円玉を次の釣銭に使える
                stockOf100Yen.Add(payment);
                change.Remove(payment);
            }
            if (payment.Is(Coin.Yen500))
            {
                // 500円を自動販売機内にストック
                stockOf500Yen.Add(payment);
                change.Remove(payment);

                // 100円のストックから400円をお釣りに移動
                var yen400 = stockOf100Yen.Take(4);
                change.AddRange(yen400);
                stockOf100Yen.RemoveRange(0, 4);
            }

            if (kindOfDrink == KindOfDrink.COKE)
            {
                stockOfCoke.RemoveAt(0);
            }
            if (kindOfDrink == KindOfDrink.DIET_COKE)
            {
                stockOfDietCoke.RemoveAt(0);
            }
            if (kindOfDrink == KindOfDrink.TEA)
            {
                stockOfTea.RemoveAt(0);
            }

            return new Drink(kindOfDrink);
        }

        /// <summary>
        /// お釣りを取り出す
        /// </summary>
        /// <returns>お釣りの金額</returns>
        public List<Coin> Refund()
        {
            var result = new List<Coin>(change);
            change.Clear();

            return result;
        }
    }
}
