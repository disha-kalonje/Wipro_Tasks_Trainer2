// Aggregation Operations in LINQ With the same Person list from Assignment 2, perform the following: a) Calculate the average age of all persons. b) Find and print the oldest and youngest person's full name.

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

class PersonAggregation
{
    static void Main(string[] args)
    {
        // Sample list of persons (modify as needed)
        List<Person> people = new List<Person>()
        {
            new Person { FirstName = "Disha", LastName = "Kalonje", Age = 23 },
            new Person { FirstName = "Esha", LastName = "Kalonje", Age = 22 },
            new Person { FirstName = "Kanak", LastName = "Kalonje", Age = 20 },
            new Person { FirstName = "Amisha", LastName = "Thakur", Age = 34 },
        };

        // a) Average age
        double averageAge = people.Average(p => p.Age);
        Console.WriteLine($"Average age: {averageAge:F2}");  // Format to two decimal places

        // b) Oldest and youngest persons
        Person oldestPerson = people.OrderByDescending(p => p.Age).FirstOrDefault();
        Person youngestPerson = people.OrderBy(p => p.Age).FirstOrDefault();

        Console.WriteLine("\nOldest person:");
        if (oldestPerson != null) // Check for empty list
        {
            Console.WriteLine($"{oldestPerson.FirstName} {oldestPerson.LastName}");
        }

        Console.WriteLine("\nYoungest person:");
        if (youngestPerson != null) // Check for empty list
        {
            Console.WriteLine($"{youngestPerson.FirstName} {youngestPerson.LastName}");
        }
    }
}
