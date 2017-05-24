using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPOQueue.Queue;

namespace PQueueTest
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Count()
        {
            var queue = new PQueue<int>();

            bool isCorrectCount0 = queue.Count() == 0;

            // 1, 2, .., n
            int n = 4;
            for (int i = 0; i < n; ++i)
                queue.Enqueue(n - i);
            bool isCorrectCount1 = queue.Count() == n;

            n /= 2;

            for (int i = 0; i < n; ++i)
                queue.Dequeue();
            bool isCorrectCount2 = queue.Count() == n;

            for (int i = 0; i < n; ++i)
                queue.Dequeue();
            bool isCorrectCount3 = queue.Count() == 0;

            queue.Enqueue(1);
            bool isCorrectCount4 = queue.Count() == 1;

            Assert.IsTrue(isCorrectCount0
                          && isCorrectCount1
                          && isCorrectCount2
                          && isCorrectCount3
                          && isCorrectCount4);
        }

        [TestMethod]
        public void ToList()
        {
            var queue = new PQueue<int>();

            // 1, 2, .., n
            int n = 5;
            for (int i = 0; i < n; ++i)
                queue.Enqueue(n - i);

            var testList = queue.ToList();

            var correctList = new List<int>();
            for (int i = 1; i <= n; ++i)
                correctList.Add(i);

            bool isEqual = true;
            for (int i = 0; isEqual && i < n; ++i)
                isEqual = testList.ElementAt(i).Equals(correctList.ElementAt(i));

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void Enqueue()
        {
            var queue = new PQueue<int>();

            // 1, 2, .., n
            int n = 4;
            for (int i = 0; i < n; ++i)
                queue.Enqueue(n - i);

            var testList = queue.ToList();

            bool isEqual = true;
            for (int i = 0; isEqual && i < n; ++i)
                isEqual = testList.ElementAt(i).Equals(i + 1);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void Dequeue()
        {
            var queue = new PQueue<int>();

            // 1, 2, .., n
            int n = 5;
            for (int i = 0; i < n; ++i)
                queue.Enqueue(n - i);

            bool isCorrectDequeue = true;

            for (int i = n - 1; isCorrectDequeue && i >= 0; --i)
            {
                int dequeued = queue.Dequeue();
                var testList = queue.ToList();

                bool isEqual = true;
                for (int j = 0; isEqual && j < i; ++j)
                    isEqual = testList.ElementAt(j).Equals(j + 1);

                isCorrectDequeue = isEqual && dequeued == i + 1;
            }

            // Empty queue test:
            queue.Dequeue();

            Assert.IsTrue(isCorrectDequeue);
        }

        [TestMethod]
        public void Minimum1()
        {
            var queue = new PQueue<int>();

            // Empty queue test:
            queue.Minimum();

            bool isCorrectMinimum = true;

            // 1, 2, .., n
            int n = 4,
                min;

            for (int i = 0; isCorrectMinimum && i < n; ++i)
            {
                min = n - i;
                queue.Enqueue(min);
                isCorrectMinimum = queue.Minimum() == min;
            }

            Assert.IsTrue(isCorrectMinimum);
        }

        [TestMethod]
        public void Minimum2()
        {
            var queue = new PQueue<int>();

            bool isCorrectMinimum = true;

            // n, n - 1, .., 1
            int n = 4,
                min = 1;

            for (int i = 0; isCorrectMinimum && i < n; ++i)
            {
                queue.Enqueue(i + 1);
                isCorrectMinimum = queue.Minimum() == min;
            }

            Assert.IsTrue(isCorrectMinimum);
        }

        [TestMethod]
        public void Minimum3()
        {
            var queue = new PQueue<int>();

            int min = 1;
            queue.Enqueue(1);
            bool isCorrectMinimum = queue.Minimum() == min;

            queue.Enqueue(2);
            isCorrectMinimum = isCorrectMinimum && queue.Minimum() == min;

            min = 2;
            queue.Dequeue();
            isCorrectMinimum = isCorrectMinimum && queue.Minimum() == min;

            min = -100;
            queue.Enqueue(min);
            isCorrectMinimum = isCorrectMinimum && queue.Minimum() == min;

            Assert.IsTrue(isCorrectMinimum);
        }

        [TestMethod]
        public void Maximum1()
        {
            var queue = new PQueue<int>();

            // Empty queue test:
            queue.Maximum();

            bool isCorrectMaximum = true;

            // n, n - 1, .., 1
            int n = 4,
                max;

            for (int i = 0; isCorrectMaximum && i < n; ++i)
            {
                max = i + 1;
                queue.Enqueue(max);
                isCorrectMaximum = queue.Maximum() == max;
            }

            Assert.IsTrue(isCorrectMaximum);
        }

        [TestMethod]
        public void Maximum2()
        {
            var queue = new PQueue<int>();

            bool isCorrectMaximum = true;

            // 1, 2, .., n
            int n = 5,
                max = n;

            for (int i = 0; isCorrectMaximum && i < n; ++i)
            {
                queue.Enqueue(n - i);
                isCorrectMaximum = queue.Maximum() == max;
            }

            Assert.IsTrue(isCorrectMaximum);
        }

        [TestMethod]
        public void Maximum3()
        {
            var queue = new PQueue<int>();

            int max = 2;
            queue.Enqueue(max);
            bool isCorrectMaximum = queue.Maximum() == max;

            queue.Enqueue(1);
            isCorrectMaximum = isCorrectMaximum && queue.Maximum() == max;

            max = 1;
            queue.Dequeue();
            isCorrectMaximum = isCorrectMaximum && queue.Maximum() == max;

            max = 100;
            queue.Enqueue(max);
            isCorrectMaximum = isCorrectMaximum && queue.Maximum() == max;

            Assert.IsTrue(isCorrectMaximum);
        }
    }
}
