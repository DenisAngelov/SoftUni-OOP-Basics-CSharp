using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email = "n/a";
    public int age = -1;

    public Employee (string emName, decimal emSalary, string emPosition, string emDepartment)
    {
        name = emName;
        salary = emSalary;
        position = emPosition;
        department = emDepartment;
    }
}

public class CompanyRoster
{
    public static void Main()
    {
        int numOfInputs = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int input = 0; input < numOfInputs; input++)
        {
            string[] data = Console.ReadLine().Split();
            Employee currEmployee = new Employee(data[0], decimal.Parse(data[1]), data[2], data[3]);

            if (data.Length == 5)
            {
                if (data[4].Contains("@"))
                    currEmployee.email = data[4];
                else
                    currEmployee.age = int.Parse(data[4]);
            }
            if (data.Length == 6)
            {
                currEmployee.email = data[4];
                currEmployee.age = int.Parse(data[5]);
            }

            employees.Add(currEmployee);
        }


        var result = employees
             .GroupBy(dep => dep.department)
             .Select(dep => new
             {
                 Department = dep.Key,
                 AverageSalary = dep.Average(emp => emp.salary),
                 Employees = dep.OrderByDescending(emp => emp.salary)
             })
             .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var employee in result.Employees)
            Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
    }
}