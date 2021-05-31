using Xunit;
using System.Linq;
using Vending.CoinMechs;
using Vending.Drinks;

namespace Vending.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "COKEçwì¸")]
        public void Test1()
        {
            var vm = new VendingMachine();

            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);

            Assert.True(
                coke != null &&
                coke.Is(KindOfDrink.COKE)
                );
        }

        [Fact(DisplayName = "Ç®íﬁÇË")]
        public void Test2()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Amount();

            Assert.Equal(400, changeAmount);
        }

        [Fact(DisplayName = "Ç®íﬁÇËÇ»Çµ")]
        public void Test6()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Amount();

            Assert.Equal(0, changeAmount);
        }

        [Fact(DisplayName = "ç›å…êÿÇÍ")]
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

        [Fact(DisplayName = "íﬁëKêÿÇÍ1")]
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

        [Fact(DisplayName = "íﬁëKêÿÇÍ2")]
        public void Test5()
        {
            var vm = new VendingMachine();

            // íﬁëK800â~è¡îÔ écÇË200â~
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // íﬁëK200â~í«â¡ écÇË400â~
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();

            // íﬁëK400â~è¡îÔ écÇË0â~
            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // íﬁëKÇ»Çµ Ç¬Ç¢Ç≈Ç…COKEÇ‡ç›å…êÿÇÍÇ»ÇÃÇ≈DIET_COKEÇ…ïœçX
            var dietCoke = vm.Buy(Coin.Yen500, KindOfDrink.DIET_COKE);

            Assert.NotNull(coke);
            Assert.Null(dietCoke);
        }
    }
}
