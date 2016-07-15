using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    string name;
    static List<string> uniqueStudents = new List<string>();

    public static int NumUniqueStudents => uniqueStudents.Distinct().Count();

    public Student(string name)
    {
        this.name = name;
        uniqueStudents.Add(name);
    }

}

public class UniqueStudentNames
{
    public static void Main()
    {
        string data = string.Empty;

        while ((data = Console.ReadLine()) != "End")
        {
            Student currStudent = new Student(data);
        }
        Console.WriteLine(Student.NumUniqueStudents);
    }
}