using System;

public class Employee
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public double BaseSalary { get; set; }

    public virtual double CalculateBonus()
    {
        return 0.0; // Default bonus for Employee (can be overridden in derived classes)
    }

    public virtual string GetEmployeeDetails()
    {
        return $"Name: {Name}\nTitle: {Title}\nGender: {Gender}\nAge: {Age}\nBase Salary: ${BaseSalary:0.00}";
    }
}

public class Manager : Employee
{
    public override double CalculateBonus()
    {
        return BaseSalary * 0.1; // 10% bonus for Manager
    }

    public override string GetEmployeeDetails()
    {
        string details = base.GetEmployeeDetails(); // Call base class method
        return details + $"\nBonus: ${CalculateBonus():0.00}";
    }
}

public class DeliveryPartner : Employee
{
    public override double CalculateBonus()
    {
        return BaseSalary * 0.2; // 20% bonus for DeliveryPartner
    }

    public override string GetEmployeeDetails()
    {
        string details = base.GetEmployeeDetails(); // Call base class method
        return details + $"\nBonus: ${CalculateBonus():0.00}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager("Disha", "Manager", "Female", 23, 50000);
        manager.CalculateBonus(0.8m); // Assuming performance rating of 80%
        manager.DisplayDetails();

        Console.WriteLine();

        DeliveryPartner deliveryPartner = new DeliveryPartner("Coco ", "Delivery Partner", "Female", 28, 30000);
        deliveryPartner.CalculateBonus(1.2m); // Assuming performance rating of 120%
        deliveryPartner.DisplayDetails();
    }
}
