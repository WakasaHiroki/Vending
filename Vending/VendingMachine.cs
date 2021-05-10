namespace Vending
{
    public class VendingMachine
    {
        private int quantityOfCoke = 5;
        private int quantityOfDietCoke = 5;
        private int quantityOfTea = 5;
        private int numberOf100Yen = 10;
        private int charge = 0;

        /// <summary>
        /// ジュースを購入する。
        /// </summary>
        /// <param name="i">投入金額。100円と500円のみ受け付ける</param>
        /// <param name="kindOfDrink">ジュースの種類。コーラ、ダイエットコーラ、お茶が指定できる。</param>
        /// <returns>指定したジュース。在庫不足や釣銭不足で変えなかった場合はnullが返される。</returns>
        public Drink Buy(int i, int kindOfDrink)
        {
            // 100円と500円だけ受け付ける
            if ((i != 100) && (i != 500))
            {
                charge += 1;
                return null;
            }

            if ((kindOfDrink == Drink.COKE) && (quantityOfCoke == 0))
            {
                charge += i;
                return null;
            }
            if ((kindOfDrink == Drink.DIET_COKE) && (quantityOfDietCoke == 0))
            {
                charge += i;
                return null;
            }
            if ((kindOfDrink == Drink.TEA) && (quantityOfTea == 0))
            {
                charge += i;
                return null;
            }

            // 釣銭不足
            if (i == 500 && numberOf100Yen < 4)
            {
                charge += i;
                return null;
            }

            if (i == 100)
            {
                // 100円玉を釣銭に使える
                numberOf100Yen++;
            }
            if (i == 500)
            {
                // 400円のおつり
                charge += (i - 100);
                // 100円玉を釣銭に使える
                numberOf100Yen -= (i - 100) / 100;
            }

            if (kindOfDrink == Drink.COKE)
            {
                quantityOfCoke--;
            }
            if (kindOfDrink == Drink.DIET_COKE)
            {
                quantityOfDietCoke--;
            }
            if (kindOfDrink == Drink.TEA)
            {
                quantityOfTea--;
            }

            return new Drink(kindOfDrink);
        }

        public int Refund()
        {
            int result = charge;
            charge = 0;
            return result;
        }
    }
}
