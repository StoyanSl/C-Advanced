using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoftProgram
{
    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMark, string wantedFilter, int studentsToTake)
        {
            if(wantedFilter=="excelent")
            {
                FilterAndTake(studentsWithMark, ExcellentFilter, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(studentsWithMark, AverageFilter, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(studentsWithMark, PoorFilter, studentsToTake);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }

        }
        private void FilterAndTake(Dictionary<string, double> studentsWithMark, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var studentMark in studentsWithMark)
            {
                if (counterForPrinted==studentsToTake)
                {
                    break;
                }
                
                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);
                    counterForPrinted++;
                }
            }
        }
        private bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }
        private bool AverageFilter(double mark)
        {
            return mark < 5.0 && mark >= 3.5;
        }
        private bool PoorFilter(double mark)
        {
            return mark<3.5;
        }
        private double Average(List<int>scoresOnTask)
        {
            int totalScore = 0;
            foreach (var score in scoresOnTask)
            {
                totalScore += score;
            }
            var percentageOfAll = totalScore / (scoresOnTask.Count * 100);
            var mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}
