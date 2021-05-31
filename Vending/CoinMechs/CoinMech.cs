using System;
using System.Collections.Generic;

namespace Vending.CoinMechs
{
    public sealed class CoinMech
    {
        private readonly Dictionary<Coin, CoinTube> _cointubes = new Dictionary<Coin, CoinTube>();
        private readonly Charge _charge = new Charge(); // 投入硬貨

        public CoinMech()
        {
            _cointubes[Coin.Yen100] = new CoinTube(Coin.Yen100);
            _cointubes[Coin.Yen500] = new CoinTube(Coin.Yen500);

            for (var i = 0; i < 10; i++)
            {
                _cointubes[Coin.Yen100].PutIn();
            }
        }

        public void PutIn(Coin payment)
        {
            _charge.PutIn(payment);

            if (!_cointubes.TryGetValue(payment, out var cointube))
            {
                throw new Exception("該当の硬貨は取り扱っていません。");
            }

            cointube.PutIn();
        }

        public bool CanRefund()
        {
            var changeAmount = _charge.Amount() - 100;
            var quantityOfYen100 = changeAmount / Coin.Yen100.Amount();

            var quantityInCoinTube = _cointubes[Coin.Yen100].Quantity();

            return !quantityInCoinTube.LessThan(new Quantity(quantityOfYen100));
        }

        public Change Refund()
        {
            // 連続購入で投入金額が500円以上になった場合とかちょっと考えすぎた
            var change = new Change();

            var chargedAmount = _charge.Amount();

            var yen100Amount = Coin.Yen100.Amount();
            while (chargedAmount > yen100Amount)
            {
                chargedAmount -= yen100Amount;
                var coin = _cointubes[Coin.Yen100].PutOut();
                change.Add(coin);
            }

            _charge.Clear();
            return change;
        }
    }
}
