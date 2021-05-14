using System;
using System.Collections.Generic;

namespace Vending
{
    public sealed class CoinMech
    {
        private readonly Dictionary<Coin, CoinTube> cointubes = new Dictionary<Coin, CoinTube>();
        private readonly Charge charge = new Charge(); // 投入硬貨

        public CoinMech()
        {
            cointubes[Coin.Yen100] = new CoinTube(Coin.Yen100);
            cointubes[Coin.Yen500] = new CoinTube(Coin.Yen500);

            for (var i = 0; i < 10; i++)
            {
                cointubes[Coin.Yen100].PutIn();
            }
        }

        public void PutIn(Coin payment)
        {
            charge.PutIn(payment);

            if (!cointubes.TryGetValue(payment, out var cointube))
            {
                throw new Exception("該当の硬貨は取り扱っていません。");
            }

            cointube.PutIn();
        }

        public bool CanRefund()
        {
            var changeAmount = charge.Amount() - 100;
            var quantityOfYen100 = changeAmount / Coin.Yen100.Amount();

            var quantityInCoinTube = cointubes[Coin.Yen100].Quantity();

            return !quantityInCoinTube.LessThan(new Quantity(quantityOfYen100));
        }

        public Change Refund()
        {
            // 連続購入で投入金額が500円以上になった場合とかちょっと考えすぎた
            var change = new Change();

            var chargedAmount = charge.Amount();

            var yen100Amount = Coin.Yen100.Amount();
            while (chargedAmount > yen100Amount)
            {
                chargedAmount -= yen100Amount;
                var coin = cointubes[Coin.Yen100].PutOut();
                change.Add(coin);
            }

            charge.Clear();
            return change;
        }
    }
}
