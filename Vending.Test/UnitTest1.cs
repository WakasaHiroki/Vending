using Xunit;
using System.Linq;

namespace Vending.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "COKEw“ü")]
        public void Test1()
        {
            var vm = new VendingMachine();

            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);

            Assert.True(
                coke != null &&
                coke.Is(KindOfDrink.COKE)
                );
        }

        [Fact(DisplayName = "‚¨’Ş‚è")]
        public void Test2()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Sum(x => x.Amount());

            Assert.Equal(400, changeAmount);
        }

        [Fact(DisplayName = "‚¨’Ş‚è‚È‚µ")]
        public void Test6()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            var change = vm.Refund();

            var changeAmount = change.Sum(x => x.Amount());

            Assert.Equal(0, changeAmount);
        }

        [Fact(DisplayName = "İŒÉØ‚ê")]
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

        [Fact(DisplayName = "’Ş‘KØ‚ê1")]
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

        [Fact(DisplayName = "’Ş‘KØ‚ê2")]
        public void Test5()
        {
            var vm = new VendingMachine();

            // ’Ş‘K800‰~Á”ï c‚è200‰~
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // ’Ş‘K200‰~’Ç‰Á c‚è400‰~
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();
            _ = vm.Buy(Coin.Yen100, KindOfDrink.COKE);
            _ = vm.Refund();

            // ’Ş‘K400‰~Á”ï c‚è0‰~
            var coke = vm.Buy(Coin.Yen500, KindOfDrink.COKE);
            _ = vm.Refund();

            // ’Ş‘K‚È‚µ ‚Â‚¢‚Å‚ÉCOKE‚àİŒÉØ‚ê‚È‚Ì‚ÅDIET_COKE‚É•ÏX
            var dietCoke = vm.Buy(Coin.Yen500, KindOfDrink.DIET_COKE);

            Assert.NotNull(coke);
            Assert.Null(dietCoke);
        }
    }
}
