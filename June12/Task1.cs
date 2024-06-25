// Implement a generic class SimpleStack<T> that mimics a stack data structure. 
// The class should have methods for Push, Pop, and Peek. 
// Ensure that the Pop method throws an InvalidOperationException when trying to pop from an empty stack.

using System;
using System.Collections.Generic;

public class SimpleStack<T>
{
    private List<T> _stack = new List<T>();

    // Push method to add an item to the stack
    public void Push(T item)
    {
        _stack.Add(item);
        Console.WriteLine($"Pushed: {item}");
    }

    // Pop method to remove and return the top item from the stack
    public T Pop()
    {
        if (_stack.Count == 0)
        {
            throw new InvalidOperationException("Cannot pop from an empty stack.");
        }
        T item = _stack[_stack.Count - 1];
        _stack.RemoveAt(_stack.Count - 1);
        Console.WriteLine($"Popped: {item}");
        return item;
    }

    // Peek method to return the top item from the stack without removing it
    public T Peek()
    {
        if (_stack.Count == 0)
        {
            throw new InvalidOperationException("Cannot peek into an empty stack.");
        }
        T item = _stack[_stack.Count - 1];
        Console.WriteLine($"Peeked: {item}");
        return item;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Create an instance of SimpleStack with integer type
            SimpleStack<int> stack = new SimpleStack<int>();

            // Push elements onto the stack
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Peek at the top element
            stack.Peek(); // Output: Peeked: 30

            // Pop elements from the stack
            stack.Pop(); // Output: Popped: 30
            stack.Pop(); // Output: Popped: 20

            // Peek at the top element
            stack.Peek(); // Output: Peeked: 10

            // Push another element
            stack.Push(40);

            // Pop the last element
            stack.Pop(); // Output: Popped: 40
            stack.Pop(); // Output: Popped: 10

            // Try to pop from an empty stack (will throw exception)
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
