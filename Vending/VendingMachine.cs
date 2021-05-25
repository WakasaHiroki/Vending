namespace Vending
{
    public class VendingMachine
    {
        private readonly Storage _storage = new Storage(); // 飲み物の格納装置
        private readonly CoinMech _coinMech = new CoinMech(); // コインメック(投入された硬貨、お釣りの返却を扱う装置)

        /// <summary>
        /// ジュースを購入する。
        /// </summary>
        /// <param name="payment">投入金額。100円と500円のみ受け付ける</param>
        /// <param name="kindOfDrink">ジュースの種類。コーラ、ダイエットコーラ、お茶が指定できる。</param>
        /// <returns>指定したジュース。在庫不足や釣銭不足で変えなかった場合はnullが返される。</returns>
        public Drink Buy(Coin payment, KindOfDrink kindOfDrink)
        {
            _coinMech.PutIn(payment);

            // 在庫確認
            if (!_storage.Has(kindOfDrink))
            {
                return null;
            }

            // 釣銭不足確認
            if (!_coinMech.CanRefund())
            {
                return null;
            }

            return _storage.PutOut(kindOfDrink);
        }

        /// <summary>
        /// お釣りを取り出す
        /// </summary>
        /// <returns>お釣り</returns>
        public Change Refund()
        {
            return _coinMech.Refund();
        }
    }
}
