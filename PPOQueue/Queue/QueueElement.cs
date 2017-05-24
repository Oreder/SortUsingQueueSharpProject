using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPOQueue.Queue
{
    public class QueueElement<T>
    {
        #region Fields
        
        public T Value { get; set; }
        public T Min { get; set; }
        public T Max { get; set; }

        #endregion

        #region Constructors

        public QueueElement() { }

        public QueueElement(T value)
        {
            Value = Min = Max = value;
        }

        public QueueElement(T value, T min, T max)
        {
            Value = value;
            Min = min;
            Max = max;
        }

        public QueueElement(QueueElement<T> other)
        {
            Value = other.Value;
            Min = other.Min;
            Max = other.Max;
        }

        #endregion

        #region Properties

        public override bool Equals(object obj)
        {
            var other = (QueueElement<T>)obj;
            return Equals(this.Value, other.Value)
                && Equals(this.Min, other.Min)
                && Equals(this.Max, other.Max);
        }

        public virtual bool EqualsValue(T value)
        {
            return Value.Equals(value);
        }

        public virtual T Minimum(QueueElement<T> other)
        {
            return Minimum(other.Min);
        }

        public virtual T Minimum(T other)
        {
            return (Comparer<T>.Default.Compare(other, Min) < 0) ? other : Min;
        }

        public virtual T Maximum(QueueElement<T> other)
        {
            return Maximum(other.Max);
        }

        public virtual T Maximum(T other)
        {
            return (Comparer<T>.Default.Compare(other, Max) > 0) ? other : Max;
        }

        #endregion
    }
}
