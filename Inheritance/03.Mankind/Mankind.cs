using System;
using System.Text.RegularExpressions;

class Human
{
    private string firstName;
    private string lastName;

    public virtual string FirstName
    {
        get
        {
            return firstName;
        }

         protected set
        {
            if (char.IsLower(value[0]))
                throw new ArgumentException("Expected upper case letter! Argument: firstName");

            firstName = value;
        }
    }

    public virtual string LastName
    {
        get
        {
            return lastName;
        }

        protected set
        {
            if (char.IsLower(value[0]))
                throw new ArgumentException(" Expected upper case letter! Argument: lastName");

            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

}

class Student  : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }

        private set
        {
            if (value.Length < 5 || value.Length > 10 || Regex.IsMatch(value, (@"[^a-zA-Z0-9]+")))
                throw new ArgumentException("Invalid faculty number!");
            
            this.facultyNumber = value;
        }
    }

    public override string FirstName
    {
        get
        {
            return base.FirstName;
        }

        protected set
        {
            if (value.Length < 4)
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            
            base.FirstName = value;
        }
    }

    public override string LastName
    {
        get
        {
            return base.LastName;
        }

        protected set
        {
            if (value.Length < 3)
                throw new ArgumentException(" Expected length at least 3 symbols! Argument: lastName ");
            
            base.LastName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\nLast Name: {this.LastName}\nFaculty number: {this.FacultyNumber}";
    }

}

class Worker : Human
{
    private double weekSalary;
    private double workHoursDay;

    public Worker(string firstName, string lastName, double weekSalary, double workHoursDay) : base(firstName, lastName)
    {
        this.LastName = lastName;
        this.WeekSalary = weekSalary;
        this.WorkHoursDay = workHoursDay;
    }

    public override string LastName
    {
        get
        {
            return base.LastName;
        }

        protected set
        {
            if (value.Length < 3)
                throw new ArgumentException(" Expected length at least 3 symbols! Argument: lastName");

            base.LastName = value;
        }
    }

    public double WeekSalary
    {
        get
        {
            return weekSalary;
        }

        private set
        {
            if (value < 10)
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");

            weekSalary = value;
        }
    }

    public double WorkHoursDay
    {
        get
        {
            return workHoursDay;
        }

        private set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            
            workHoursDay = value;
        }
    }

    public double SalaryPerHour
    {
        get
        {
            return WeekSalary / (WorkHoursDay * 5);
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\nLast Name: {this.LastName}\nWeek Salary: {this.WeekSalary:F2}\nHours per day: {this.WorkHoursDay:F2}\nSalary per hour: {SalaryPerHour:F2}";
    }

}

public class Mankind
{
    public static void Main()
    {
        string[] studentData = Console.ReadLine().Split();
        string[] workerData = Console.ReadLine().Split();

        try
        {
            Student student = new Student(studentData[0], studentData[1], studentData[2]);
            Worker worker = new Worker(workerData[0], workerData[1], double.Parse(workerData[2]), double.Parse(workerData[3]));
            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}