using System;

class Student
{
    public string Name;
    public int Id;
    public string Grade;
}

class StudentView
{
    public void Display(Student student)
    {
        Console.WriteLine(student.Name);
    }
}