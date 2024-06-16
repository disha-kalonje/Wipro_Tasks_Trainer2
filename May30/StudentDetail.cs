using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_details
{

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string EmailId { get; set; }
        public int PhoneNumber { get; set; }
        public string Gender { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            // Get student details from user input
            Console.WriteLine("Enter student details:");
            Console.Write("First Name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            student.LastName = Console.ReadLine();

            // Validate and get age
            bool isValidAge = false;
            while (!isValidAge)
            {
                try
                {
                    Console.Write("Age: ");
                    student.Age = int.Parse(Console.ReadLine());
                    if (student.Age < 0)
                    {
                        Console.WriteLine("Age cannot be negative. Please enter a valid age.");
                    }
                    else
                    {
                        isValidAge = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for age.");
                }
            }

            Console.Write("Address 1: ");
            student.Address1 = Console.ReadLine();
            Console.Write("Address 2 (optional): ");
            student.Address2 = Console.ReadLine();
            Console.Write("City: ");
            student.City = Console.ReadLine();
            Console.Write("State: ");
            student.State = Console.ReadLine();
            Console.Write("Email Id: ");
            student.EmailId = Console.ReadLine();

            // Validate and get phone number
            bool isValidPhone = false;
            while (!isValidPhone)
            {
                try
                {
                    Console.Write("Phone Number: ");
                    student.PhoneNumber = int.Parse(Console.ReadLine());
                    isValidPhone = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for phone number.");
                }
            }

            Console.Write("Gender (M/F): ");
            student.Gender = Console.ReadLine().ToUpper(); // Convert to uppercase for easier validation

            // Validate and get valid gender input
            while (student.Gender != "M" && student.Gender != "F")
            {
                Console.WriteLine("Invalid gender. Please enter 'M' for Male or 'F' for Female.");
                Console.Write("Gender (M/F): ");
                student.Gender = Console.ReadLine().ToUpper();
            }

            // Display student details with clear formatting
            Console.WriteLine("\nStudent Details Entered by you:");
            Console.WriteLine($"First Name: {student.FirstName}");
            Console.WriteLine($"Last Name: {student.LastName}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"Address 1: {student.Address1}");
            if (!string.IsNullOrEmpty(student.Address2)) 
            {
                Console.WriteLine($"Address 2: {student.Address2}");
            }
            Console.WriteLine($"City: {student.City}");
            Console.WriteLine($"State: {student.State}");
            Console.WriteLine($"Email Id: {student.EmailId}");
            Console.WriteLine($"Phone Number: {student.PhoneNumber}");
            Console.WriteLine($"Gender: {student.Gender}");
        }
    }
}
