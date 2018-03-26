using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BashSoftProgram
{
    public  class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake)
        {
            if (comparison=="ascending")
            {
              this.PrintStudents(studentsMarks.OrderBy(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(studentsMarks.OrderByDescending(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }
        private  void PrintStudents(Dictionary<string, double> dataSorted)
        {
            foreach (var student in dataSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}
