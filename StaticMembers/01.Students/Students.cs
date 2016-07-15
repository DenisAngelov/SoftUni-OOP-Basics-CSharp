using System;

class Student
{
    string name;
    static int numOfStudents = 0;

    public static int NumberOfStudents => numOfStudents;

    public Student(string name)
    {
        this.name = name;
        numOfStudents++;
    }
}

public class Students
{
    public static void Main()
    {
        string data = string.Empty;

        while ((data = Console.ReadLine()) != "End")
        {
            Student currStudent = new Student(data);
        }
        Console.WriteLine(Student.NumberOfStudents);
    }
}