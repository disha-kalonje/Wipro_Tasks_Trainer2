// Complex Queries with Filtering and Ordering Given a list of Person objects (with FirstName, LastName, and Age properties), perform the following: a) Use LINQ to select and print names of all persons whose age is over 30. b) Order the persons by last name and then by first name and print the sorted list. 
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

class ComplexPersonQueries
{
    static void Main(string[] args)
    {
        // list of persons
        List<Person> people = new List<Person>()
        {
            new Person { FirstName = "Disha", LastName = "Kalonje", Age = 23 },
            new Person { FirstName = "Esha", LastName = "Kalonje", Age = 22 },
            new Person { FirstName = "Kanak", LastName = "Kalonje", Age = 20 },
            new Person { FirstName = "Amisha", LastName = "Thakur", Age = 34 },
        };

        // a) Persons over 30
        var over30 = people.Where(p => p.Age > 30)
                           .Select(p => $"{p.FirstName} {p.LastName}");

        Console.WriteLine("People over 30:");
        foreach (string name in over30)
        {
            Console.WriteLine(name);
        }

        // b) Ordered by last name then by first name
        var orderedPeople = people.OrderBy(p => p.LastName)
                                   .ThenBy(p => p.FirstName);

        Console.WriteLine("\nPeople ordered by last name then first name:");
        foreach (Person person in orderedPeople)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}
