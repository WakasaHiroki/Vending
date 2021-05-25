using System;

namespace Vending
{
    public sealed class Quantity
    {
        private readonly int _value;

        public Quantity(int value)
        {
            if (value < 0)
            {
                throw new Exception("数量は0以上にしてください。");
            }

            _value = value;
        }

        public bool IsNone()
        {
            return _value == 0;
        }

        public bool LessThan(Quantity quantity)
        {
            return _value < quantity._value;
        }

        /// <summary>
        /// 加算
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Quantity Add(Quantity quantity)
        {
            return new Quantity(_value + quantity._value);
        }

        /// <summary>
        /// 減算
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Quantity Subtract(Quantity quantity)
        {
            // 減算してマイナスになったらコンストラクタで弾かれる
            return new Quantity(_value - quantity._value);
        }
    }
}
