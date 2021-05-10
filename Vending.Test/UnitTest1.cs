using Xunit;

namespace Vending.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "COKE購入")]
        public void Test1()
        {
            var vm = new VendingMachine();

            var coke = vm.Buy(500, Drink.COKE);

            Assert.True(
                coke != null &&
                coke.Kind == Drink.COKE
                );
        }

        [Fact(DisplayName = "お釣り")]
        public void Test2()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(500, Drink.COKE);
            var charge = vm.Refund();

            Assert.Equal(400, charge);
        }

        [Fact(DisplayName = "在庫切れ")]
        public void Test3()
        {
            var vm = new VendingMachine();

            int cnt = 5;
            for (var i = 0; i < cnt; i++)
            {
                _ = vm.Buy(100, Drink.COKE);
            }

            var drink = vm.Buy(100, Drink.COKE);

            Assert.Null(drink);
        }

        [Fact(DisplayName = "釣銭切れ")]
        public void Test4()
        {
            var vm = new VendingMachine();

            int cnt = 2;
            for (var i = 0; i < cnt; i++)
            {
                _ = vm.Buy(500, Drink.COKE);
            }

            var drink = vm.Buy(500, Drink.COKE);

            Assert.Null(drink);
        }

        [Fact(DisplayName = "釣銭切れ")]
        public void Test5()
        {
            var vm = new VendingMachine();

            // 釣銭800円消費 残り200円
            _ = vm.Buy(500, Drink.COKE);
            _ = vm.Buy(500, Drink.COKE);

            // 釣銭200円追加 残り400円
            _ = vm.Buy(100, Drink.COKE);
            _ = vm.Buy(100, Drink.COKE);

            // 釣銭400円消費 残り0円
            var coke = vm.Buy(500, Drink.COKE);

            // 釣銭なし ついでにCOKEも在庫切れなのでDIET_COKEに変更
            var dietCoke = vm.Buy(500, Drink.DIET_COKE);
            
            Assert.NotNull(coke);
            Assert.Null(dietCoke);
        }
    }
}
