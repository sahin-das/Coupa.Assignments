using System;

namespace Assignment8
{
    class Program
    {
        public static void Main(string[] args)
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue(2, "Task 2");
            queue.Enqueue(1, "Task 1");
            queue.Enqueue(3, "Task 3");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Contains("Task 2"));
        }
    }

    public class PriorityQueue<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> elements;

        public PriorityQueue()
        {
            elements = new SortedDictionary<int, IList<T>>();
        }

        public PriorityQueue(IDictionary<int, IList<T>> elements)
        {
            this.elements = elements;
        }

        private int Count
        {
            get { return elements.Values.Sum(list => list.Count); }
        }

        public bool Contains(T item)
        {
            return elements.Values.Any(list => list.Contains(item));
        }

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("The queue is empty.");

            int highestPriority = GetHighestPriority();
            T item = elements[highestPriority][0];
            elements[highestPriority].RemoveAt(0);

            if (elements[highestPriority].Count == 0)
            {
                elements.Remove(highestPriority);
            }

            return item;
        }

        public void Enqueue(int priority, T item)
        {
            if (!elements.ContainsKey(priority))
            {
                elements[priority] = new List<T>();
            }
            elements[priority].Add(item);
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("The queue is empty.");

            var highestPriority = GetHighestPriority();
            return elements[highestPriority][0];
        }

        private int GetHighestPriority()
        {
            return elements.Keys.Min();
        }
    }
}
