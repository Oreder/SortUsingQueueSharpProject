using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPOQueue.Queue
{
    public class PQueue<T> : QueueBase<T>
    {
        public override void Enqueue(T value)
        {
            QueueElement<T> e = null;

            if (!head.Any())
                e = new QueueElement<T>(value);
            else
            {
                var top = head.Peek();  // return top of stack without removing it
                e = new QueueElement<T>(value, top.Minimum(value), top.Maximum(value));
            }

            head.Push(e);
        }

        public override T Dequeue()
        {
            if (!tail.Any())
            {
                if (!head.Any())
                    return default(T);      // if stacks head and tail are all free

                while (head.Any())
                {
                    var popped = head.Pop();

                    if (tail.Any())
                    {
                        var peeked = tail.Peek();
                        popped.Min = peeked.Minimum(popped.Value);
                        popped.Max = peeked.Maximum(popped.Value);
                    }
                    else
                    {
                        popped.Min = popped.Value;
                        popped.Max = popped.Value;
                    }

                    tail.Push(popped);
                }
            }

            var e = tail.Pop();
            return e.Value;
        }

        public override T Maximum()
        {
            bool emptyHead = !head.Any(),
                 emptyTail = !tail.Any();

            if (emptyHead && emptyTail)
                return default(T);

            if (emptyHead)
            {
                var e = tail.Peek();
                return e.Max;
            }

            if (emptyTail)
            {
                var e = head.Peek();
                return e.Max;
            }

            return head.Peek().Maximum(tail.Peek());
        }

        public override T Minimum()
        {
            bool emptyHead = !head.Any(),
                 emptyTail = !tail.Any();

            if (emptyHead && emptyTail)
                return default(T);

            if (emptyHead)
            {
                var e = tail.Peek();
                return e.Min;
            }

            if (emptyTail)
            {
                var e = head.Peek();
                return e.Min;
            }

            return head.Peek().Minimum(tail.Peek());
        }
    }
}
