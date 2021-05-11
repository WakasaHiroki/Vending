namespace Vending
{
    public class VendingMachine
    {
        private int stockOfCoke = 5; // コーラの在庫数
        private int stockOfDietCoke = 5; // ダイエットコーラの在庫数
        private int stockOfTea = 5; // お茶の在庫数
        private int stockOf100Yen = 10; // 100円玉の在庫
        private int change = 0; // お釣り

        /// <summary>
        /// ジュースを購入する。
        /// </summary>
        /// <param name="payment">投入金額。100円と500円のみ受け付ける</param>
        /// <param name="kindOfDrink">ジュースの種類。コーラ、ダイエットコーラ、お茶が指定できる。</param>
        /// <returns>指定したジュース。在庫不足や釣銭不足で変えなかった場合はnullが返される。</returns>
        public Drink Buy(int payment, int kindOfDrink)
        {
            // 100円と500円だけ受け付ける
            if ((payment != 100) && (payment != 500))
            {
                change += payment;
                return null;
            }

            if ((kindOfDrink == Drink.COKE) && (stockOfCoke == 0))
            {
                change += payment;
                return null;
            }
            if ((kindOfDrink == Drink.DIET_COKE) && (stockOfDietCoke == 0))
            {
                change += payment;
                return null;
            }
            if ((kindOfDrink == Drink.TEA) && (stockOfTea == 0))
            {
                change += payment;
                return null;
            }

            // 釣銭不足
            if (payment == 500 && stockOf100Yen < 4)
            {
                change += payment;
                return null;
            }

            if (payment == 100)
            {
                // 100円玉を釣銭に使える
                stockOf100Yen++;
            }
            if (payment == 500)
            {
                // 400円のおつり
                change += (payment - 100);
                // 100円玉を釣銭に使える
                stockOf100Yen -= (payment - 100) / 100;
            }

            if (kindOfDrink == Drink.COKE)
            {
                stockOfCoke--;
            }
            if (kindOfDrink == Drink.DIET_COKE)
            {
                stockOfDietCoke--;
            }
            if (kindOfDrink == Drink.TEA)
            {
                stockOfTea--;
            }

            return new Drink(kindOfDrink);
        }

        /// <summary>
        /// お釣りを取り出す
        /// </summary>
        /// <returns>お釣りの金額</returns>
        public int Refund()
        {
            int result = change;
            change = 0;
            return result;
        }
    }
}
