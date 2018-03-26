using System;
using System.Collections.Generic;
using System.Text;
using BashSoftProgram.Exceptions;

public class Course
{
    private string name;
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidStringException();
            }
            this.name = value;
        }
    }
    private Dictionary<string, Student> studentsByName;
    public IReadOnlyDictionary<string, Student> StudentsByName
    {
        get {return this.studentsByName; }
    }

    public const int numberOfTasksInExam = 5;
    public const int maxScoreOnExamTask = 100;
    public Course(string name)
    {
        this.Name = name;

        this.studentsByName = new Dictionary<string, Student>();
    }
    public void EnrollStudent(Student student)
    {
        if (this.studentsByName.ContainsKey(student.UserName))
        {
            throw new DuplicateEntryInStructureException(student.UserName, this.Name);
        }
        this.studentsByName.Add(student.UserName, student);
    }
}

