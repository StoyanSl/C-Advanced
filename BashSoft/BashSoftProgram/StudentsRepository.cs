using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoftProgram
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
        }
        private static void ReadData()
        {
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                var args = input.Trim().Split(' ').ToList();
                var course = args[0];
                var student = args[1];
                var mark = int.Parse(args[2]);
                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new Dictionary<string, List<int>>());

                }
                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course].Add(student, new List<int>());

                }
                studentsByCourse[course][student].Add(mark);
                input = Console.ReadLine();
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }
        private static bool IsQueryForCoursePossible(string courseName)
        {
            if(isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
            return false;
        }
        private static bool IsQueryForStudentPossible(string courseName,string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName)&&studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        public static void GetStudentScoresFromCourse(string courseName,string studentUserName)
        {
            if (IsQueryForStudentPossible(courseName,studentUserName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(studentUserName, studentsByCourse[courseName][studentUserName]));
            }
        }
        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}..");
                foreach (var student in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(student);
                }
            }
        }
    }
}
