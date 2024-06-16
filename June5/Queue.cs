using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_june6
{
    public class Queue
    {
        private int[] items; // Private array to store queue elements
        private int front; // Private variable for front index
        private int rear; // Private variable for rear index

        public Queue(int capacity) // Public constructor with capacity parameter
        {
            items = new int[capacity];
            front = -1;
            rear = -1;
        }

        public bool IsEmpty() // Public method to check if queue is empty
        {
            return front == -1;
        }

        public bool IsFull() // Public method to check if queue is full
        {
            return rear == items.Length - 1;
        }

        public void Enqueue(int value) // Public method to enqueue (add) an element
        {
            if (IsFull())
            {
                Console.WriteLine("Queue overflow");
                return;
            }

            if (IsEmpty())
            {
                front = 0;
            }

            rear++;
            items[rear] = value;
        }

        public int Dequeue() // Public method to dequeue (remove) an element
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue underflow");
                return -1; // Indicate error
            }

            int value = items[front];

            if (front == rear) // If only one element, reset both front and rear
            {
                front = rear = -1;
            }
            else
            {
                front++;
            }

            return value;
        }
    }

    internal class Program
    {
       public static void Main(string[] args)
        {
            Queue queue = new Queue(5); // Create a queue with capacity 5

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Console.WriteLine("Dequeued element: {0}", queue.Dequeue()); // Output: Dequeued element: 10
            Console.WriteLine("Dequeued element: {0}", queue.Dequeue()); // Output: Dequeued element: 20

            queue.Enqueue(40);
            queue.Enqueue(50);

            Console.WriteLine("Front element: {0}", queue.Dequeue()); // Output: Dequeued element: 30
        }
        
    }
}



