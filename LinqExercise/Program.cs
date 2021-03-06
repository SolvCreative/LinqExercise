﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
           
            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine("...........................");

            var average = numbers.Average();
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine("...........................");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascOrder = numbers.OrderBy(num => num);
            foreach (var num in ascOrder)
            {
                Console.WriteLine(num);
            }
            
            Console.WriteLine("...........................");

            var desOrder = numbers.OrderByDescending(num => num);
            foreach (var num in desOrder)
            {
               Console.WriteLine(num);
            }
            
            Console.WriteLine("...........................");

            //Print to the console only the numbers greater than 6
            
            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }
            
            Console.WriteLine("...........................");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            foreach (var num in ascOrder.Take(4))
            {
                Console.WriteLine(num);
            }

           
            Console.WriteLine("...........................");
            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 42;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("...........................");
            
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var filtered = employees.Where(person => person.FirstName.StartsWith ('C') || person.FirstName.StartsWith ('S')).OrderBy(person => person.FirstName);

            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }
            
            Console.WriteLine("...........................");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var empOverTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            foreach (var employee in empOverTwentySix)
            {
                Console.WriteLine($"Full name: {employee.FullName}, Age: {employee.Age}");
            }
            
            Console.WriteLine("...........................");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var thisList = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);
            var sumOfYOE = thisList.Sum(person => person.YearsOfExperience);
            var avgOfYOE = thisList.Average(person => person.YearsOfExperience);
           
            Console.WriteLine($"The sum: {sumOfYOE}. The average: {avgOfYOE}");
            
            Console.WriteLine("...........................");

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Bruce", "Wayne", 77, 5)).ToList();
            foreach (var person in employees)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
            
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
