using BashSoftProgram.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text.RegularExpressions;


namespace BashSoftProgram
{
    public  class StudentRepository
    {
        private bool isDataInitialized = false;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        public StudentRepository(RepositorySorter sorter,RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
          
        }

        public void ShowWholeData()
        {
            foreach (var course in this.courses)
            {
                Console.WriteLine($"Course: {course.Key}");
                foreach (var student in course.Value.StudentsByName)
                {
                    Console.WriteLine($"---Student: {student.Key}");
                }
            }
        }
        public void LoadData(string fileName)
        {
            if (!this.isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                this.students = new Dictionary<string, Student>();
                this.courses = new Dictionary<string, Course>();

                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
                
            }
        }
        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedException);

            }
            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
        }
        private void ReadData(string fileName)
        {
            string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
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
                       
                        var courseName = currentMatch.Groups[1].Value;
                        var username = currentMatch.Groups[2].Value;
                        var scoresStr = currentMatch.Groups[3].Value;
                        try
                        {
                            int[] scores = scoresStr.Split(new string[] { " "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                            if (scores.Any(x=>x>100||x<0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScores);
                            }
                            if (!this.students.ContainsKey(username))
                            {
                                this.students.Add(username, new Student(username));
                            }
                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[username];
                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName,scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {

                            OutputWriter.DisplayException(fex.Message+$"at line : +{line}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidPathException();
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }
        private bool IsQueryForCoursePossible(string courseName)
        {
            if(isDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
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
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }
        private bool IsQueryForStudentPossible(string courseName,string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName)&&this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        public void GetStudentScoresFromCourse(string courseName,string studentUserName)
        {
            if (IsQueryForStudentPossible(courseName,studentUserName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string,double>(studentUserName, this.courses[courseName].StudentsByName[studentUserName].MarksByCourseName[courseName]));
            }
        }
        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}..");
                foreach (var student in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, student.Key);
                }
            }
        }
        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake==null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count();
                }
                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }
        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count();
                }
                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                sorter.OrderAndTake(marks, comparison, studentsToTake.Value);

            }
        }
    }
}
