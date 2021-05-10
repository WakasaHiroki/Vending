using Xunit;

namespace Vending.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "COKEçwì¸")]
        public void Test1()
        {
            var vm = new VendingMachine();

            var coke = vm.Buy(500, Drink.COKE);

            Assert.True(
                coke != null &&
                coke.Kind == Drink.COKE
                );
        }

        [Fact(DisplayName = "Ç®íﬁÇË")]
        public void Test2()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(500, Drink.COKE);
            var charge = vm.Refund();

            Assert.Equal(400, charge);
        }

        [Fact(DisplayName = "ç›å…êÿÇÍ")]
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

        [Fact(DisplayName = "íﬁëKêÿÇÍ")]
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

        [Fact(DisplayName = "íﬁëKêÿÇÍ")]
        public void Test5()
        {
            var vm = new VendingMachine();

            // íﬁëK800â~è¡îÔ écÇË200â~
            _ = vm.Buy(500, Drink.COKE);
            _ = vm.Buy(500, Drink.COKE);

            // íﬁëK200â~í«â¡ écÇË400â~
            _ = vm.Buy(100, Drink.COKE);
            _ = vm.Buy(100, Drink.COKE);

            // íﬁëK400â~è¡îÔ écÇË0â~
            var coke = vm.Buy(500, Drink.COKE);

            // íﬁëKÇ»Çµ Ç¬Ç¢Ç≈Ç…COKEÇ‡ç›å…êÿÇÍÇ»ÇÃÇ≈DIET_COKEÇ…ïœçX
            var dietCoke = vm.Buy(500, Drink.DIET_COKE);
            
            Assert.NotNull(coke);
            Assert.Null(dietCoke);
        }
    }
}
