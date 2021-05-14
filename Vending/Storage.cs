using System;
using System.Collections.Generic;

namespace Vending
{
    public sealed class Storage
    {
        private readonly Dictionary<KindOfDrink, Stock> stocks = new Dictionary<KindOfDrink, Stock>();

        public Storage()
        {
            var stockOfCoke = new Stock(KindOfDrink.COKE); // コーラの在庫数
            var stockOfDietCoke = new Stock(KindOfDrink.DIET_COKE); // ダイエットコーラの在庫数
            var stockOfTea = new Stock(KindOfDrink.TEA); // お茶の在庫数

            // 在庫補充
            stockOfCoke.Replenish(new Quantity(5));
            stockOfDietCoke.Replenish(new Quantity(5));
            stockOfTea.Replenish(new Quantity(5));

            stocks[KindOfDrink.COKE] = stockOfCoke;
            stocks[KindOfDrink.DIET_COKE] = stockOfDietCoke;
            stocks[KindOfDrink.TEA] = stockOfTea;
        }

        public bool Has(KindOfDrink kindOfDrink)
        {
            if (!stocks.TryGetValue(kindOfDrink, out var stock))
            {
                throw new Exception("該当のジュースを取り扱っていません。");
            }

            return !stock.IsEmpty();
        }

        public Drink PutOut(KindOfDrink kindOfDrink)
        {
            if (!stocks.TryGetValue(kindOfDrink, out var stock))
            {
                throw new Exception("該当のジュースを取り扱っていません。");
            }

            return stock.PutOut();
        }
    }
}
