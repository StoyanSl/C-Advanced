using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BashSoftProgram
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void ShowWholeData()
        {
            foreach (var course in studentsByCourse)
            {
                Console.WriteLine($"Course: {course.Key}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"---Student: {student.Key}");
                }
            }
        }
        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
        }
        private static void ReadData(string fileName)
        {
            string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            Regex rgx = new Regex(pattern);
            string path = SessionData.currentPath+"\\"+fileName;
            if (File.Exists(path))
            {
               var AllInputLines = File.ReadAllLines(path);
                for (int line = 0; line < AllInputLines.Count(); line++)
                {
                    if (!string.IsNullOrEmpty(AllInputLines[line])&&rgx.IsMatch(AllInputLines[line]))
                    {
                    
                        Match currentMatch = rgx.Match(AllInputLines[line]);
                       
                        var course = currentMatch.Groups[1].Value;
                        var student = currentMatch.Groups[2].Value;
                        int mark;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out mark);
                        if (hasParsedScore && mark >= 0 && mark <= 100)
                        {
                           
                            if (!studentsByCourse.ContainsKey(course))
                            {
                                studentsByCourse.Add(course, new Dictionary<string, List<int>>());

                            }
                            if (!studentsByCourse[course].ContainsKey(student))
                            {
                                studentsByCourse[course].Add(student, new List<int>());

                            }
                            studentsByCourse[course][student].Add(mark);
                        }
                        
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
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
        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake==null)
                {
                    studentsToTake = studentsByCourse[courseName].Count();
                }
                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);

            }
        }
        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count();
                }
                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);

            }
        }
    }
}
