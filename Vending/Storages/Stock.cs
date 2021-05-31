using System;
using System.Collections.Generic;
using System.Linq;
using Vending.Drinks;

namespace Vending.Storages
{
    public sealed class Stock
    {
        private readonly List<Drink> _drinks = new List<Drink>();
        private readonly KindOfDrink _kind;

        public Stock(KindOfDrink kind)
        {
            _kind = kind;
        }

        public void Replenish(Quantity maxQuantity)
        {
            var quantity = new Quantity(_drinks.Count);

            while (quantity.LessThan(maxQuantity))
            {
                _drinks.Add(new Drink(_kind));
                quantity = new Quantity(_drinks.Count);
            }
        }

        public bool IsEmpty()
        {
            return _drinks.Count == 0;
        }

        public Drink PutOut()
        {
            if (IsEmpty())
            {
                throw new Exception("在庫がありません。");
            }

            var drink = _drinks.First();

            _drinks.Remove(drink);
            return drink;
        }
    }
}
