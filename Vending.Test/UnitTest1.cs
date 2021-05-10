using Xunit;

namespace Vending.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "COKE�w��")]
        public void Test1()
        {
            var vm = new VendingMachine();

            var coke = vm.Buy(500, Drink.COKE);

            Assert.True(
                coke != null &&
                coke.Kind == Drink.COKE
                );
        }

        [Fact(DisplayName = "���ނ�")]
        public void Test2()
        {
            var vm = new VendingMachine();

            _ = vm.Buy(500, Drink.COKE);
            var charge = vm.Refund();

            Assert.Equal(400, charge);
        }

        [Fact(DisplayName = "�݌ɐ؂�")]
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

        [Fact(DisplayName = "�ޑK�؂�")]
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

        [Fact(DisplayName = "�ޑK�؂�")]
        public void Test5()
        {
            var vm = new VendingMachine();

            // �ޑK800�~���� �c��200�~
            _ = vm.Buy(500, Drink.COKE);
            _ = vm.Buy(500, Drink.COKE);

            // �ޑK200�~�ǉ� �c��400�~
            _ = vm.Buy(100, Drink.COKE);
            _ = vm.Buy(100, Drink.COKE);

            // �ޑK400�~���� �c��0�~
            var coke = vm.Buy(500, Drink.COKE);

            // �ޑK�Ȃ� ���ł�COKE���݌ɐ؂�Ȃ̂�DIET_COKE�ɕύX
            var dietCoke = vm.Buy(500, Drink.DIET_COKE);
            
            Assert.NotNull(coke);
            Assert.Null(dietCoke);
        }
    }
}
