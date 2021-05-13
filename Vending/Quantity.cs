using System;

namespace Vending
{
    public sealed class Quantity
    {
        private readonly int value;

        public Quantity(int value)
        {
            if (value < 0)
            {
                throw new Exception("数量は0以上にしてください。");
            }

            this.value = value;
        }

        public bool IsNone()
        {
            return value == 0;
        }

        public bool Is(Quantity quantity)
        {
            return value == quantity.value;
        }

        public bool LessThan(Quantity quantity)
        {
            return value < quantity.value;
        }

        /// <summary>
        /// 加算
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Quantity Add(Quantity quantity)
        {
            return new Quantity(value + quantity.value);
        }

        /// <summary>
        /// 減算
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Quantity Subtract(Quantity quantity)
        {
            // 減算してマイナスになったらコンストラクタで弾かれる
            return new Quantity(value - quantity.value);
        }
    }
}
