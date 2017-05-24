using System.Collections.Generic;
using System.Linq;

namespace PPOQueue.Queue
{
    public abstract class QueueBase<T>
    {
        #region Protected Stacks

        protected Stack<QueueElement<T>> head = new Stack<QueueElement<T>>();
        protected Stack<QueueElement<T>> tail = new Stack<QueueElement<T>>();

        #endregion

        public abstract void Enqueue(T value);
        public abstract T Dequeue();
        public abstract T Maximum();
        public abstract T Minimum();

        #region Virtual methods

        public virtual int Count()
        {
            return head.Count + tail.Count;
        }

        public virtual List<T> ToList()
        {
            List<T> res = new List<T>();

            foreach (var e in head)
                res.Add(e.Value);

            foreach (var e in tail.Reverse())
                res.Add(e.Value);

            return res;
        }

        #endregion
    }
}
