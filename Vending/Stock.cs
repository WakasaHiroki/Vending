using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending
{
    public sealed class Stock
    {
        private readonly List<Drink> drinks = new List<Drink>();
        private readonly KindOfDrink kind;

        public Stock(KindOfDrink kind)
        {
            this.kind = kind;
        }

        public void Replenish(Quantity maxQuantity)
        {
            var quantity = new Quantity(drinks.Count);

            while (quantity.LessThan(maxQuantity))
            {
                drinks.Add(new Drink(kind));
                quantity = new Quantity(drinks.Count);
            }
        }

        public bool IsEmpty()
        {
            return drinks.Count == 0;
        }

        public Drink PutOut()
        {
            if (IsEmpty())
            {
                throw new Exception("在庫がありません。");
            }

            var drink = drinks.First();

            drinks.Remove(drink);
            return drink;
        }
    }
}
