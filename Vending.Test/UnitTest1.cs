using Xunit;
using System.Linq;
using Vending.CoinMechs;
using Vending.Drinks;

namespace Vending.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "COKE�w��")]
        public void Test1()
        {
            var vm = new VendingMachine();

            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);

            Assert.True(
                coke != null &&
                coke.Is(KindOfDrink.COKE)
                );
        }

        [Fact(DisplayName = "���ނ�")]
        public void Test2()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Amount();

            Assert.Equal(400, changeAmount);
        }

        [Fact(DisplayName = "���ނ�Ȃ�")]
        public void Test6()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Amount();

            Assert.Equal(0, changeAmount);
        }

        [Fact(DisplayName = "�݌ɐ؂�")]
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

        [Fact(DisplayName = "�ޑK�؂�1")]
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

        [Fact(DisplayName = "�ޑK�؂�2")]
        public void Test5()
        {
            var vm = new VendingMachine();

            // �ޑK800�~���� �c��200�~
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // �ޑK200�~�ǉ� �c��400�~
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();

            // �ޑK400�~���� �c��0�~
            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // �ޑK�Ȃ� ���ł�COKE���݌ɐ؂�Ȃ̂�DIET_COKE�ɕύX
            var dietCoke = vm.Buy(Coin.Yen500, KindOfDrink.DIET_COKE);

            Assert.NotNull(coke);
            Assert.Null(dietCoke);
        }
    }
}
