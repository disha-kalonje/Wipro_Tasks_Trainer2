// Create a CustomStack class in C# with operations Push, Pop, Peek, and IsEmpty. Demonstrate its LIFO behavior by pushing integers onto the stack, then popping and displaying them until the stack is empty.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_june5
{
    public class CustomStack
    {
    private int[] items;
    private int top = -1;

        public CustomStack(int capacity)
        {
            items = new int[capacity];
        }

        public void Push(int value)
        {
            if (IsFull())
            {
                throw new Exception("Stack overflow");
            }
            items[++top] = value;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack underflow");
            }
            return items[top--];
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }
            return items[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == items.Length - 1;
        }

        public int Count
        {
            get { return top + 1; }
        }
    }

  public static void Main(string[] args)
  {
    CustomStack stack = new CustomStack(5);

    Console.WriteLine("Total elements: {0}", stack.Count); // Output: Total elements: 0

    stack.Push(10);
    Console.WriteLine("Pushed 10");

    Console.WriteLine("Total elements: {0}", stack.Count); // Output: Total elements: 1

    Console.WriteLine("Peek: {0}", stack.Peek()); // Output: Peek: 10

    int poppedValue = stack.Pop();
    Console.WriteLine("Popped: {0}", poppedValue); // Output: Popped: 10

    Console.WriteLine("Total elements: {0}", stack.Count); // Output: Total elements: 0

    Console.WriteLine("Is stack empty: {0}", stack.IsEmpty()); // Output: Is stack empty: True
  }

}
