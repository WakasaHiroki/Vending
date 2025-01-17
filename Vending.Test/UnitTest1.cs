using Xunit;
using System.Linq;
using Vending.CoinMechs;
using Vending.Drinks;

namespace Vending.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "COKE購入")]
        public void Test1()
        {
            var vm = new VendingMachine();

            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);

            Assert.True(
                coke != null &&
                coke.Is(KindOfDrink.COKE)
                );
        }

        [Fact(DisplayName = "お釣り")]
        public void Test2()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Amount();

            Assert.Equal(400, changeAmount);
        }

        [Fact(DisplayName = "お釣りなし")]
        public void Test6()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Amount();

            Assert.Equal(0, changeAmount);
        }

        [Fact(DisplayName = "在庫切れ")]
        public void Test3()
        {
            var vm = new VendingMachine();

            int cnt = 5;
            for (var i = 0; i < cnt; i++)
            {
                _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            }

            var drink = vm.Buy(Coin.Yen100, KindOfDrink.COKE);

            Assert.Null(drink);
        }

        [Fact(DisplayName = "釣銭切れ1")]
        public void Test4()
        {
            var vm = new VendingMachine();

            int cnt = 2;
            for (var i = 0; i < cnt; i++)
            {
                _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
                _ = vm.Refund();
            }

            var drink = vm.Buy(Coin.Yen500, KindOfDrink.COKE);

            Assert.Null(drink);
        }

        [Fact(DisplayName = "釣銭切れ2")]
        public void Test5()
        {
            var vm = new VendingMachine();

            // 釣銭800円消費 残り200円
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // 釣銭200円追加 残り400円
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();

            // 釣銭400円消費 残り0円
            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // 釣銭なし ついでにCOKEも在庫切れなのでDIET_COKEに変更
            var dietCoke = vm.Buy(Coin.Yen500, KindOfDrink.DIET_COKE);

            Assert.NotNull(coke);
            Assert.Null(dietCoke);
        }
    }
}
