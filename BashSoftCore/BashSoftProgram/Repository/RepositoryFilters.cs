using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoftProgram
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if(wantedFilter=="excelent")
            {
                FilterAndTake(wantedData, ExcellentFilter, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, AverageFilter, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, PoorFilter, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }

        }
        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userNamePoints in wantedData)
            {
                if (counterForPrinted==studentsToTake)
                {
                    break;
                }
                double avarageMark = Average(userNamePoints.Value);
                if (givenFilter(avarageMark))
                {
                    OutputWriter.PrintStudent(userNamePoints);
                    counterForPrinted++;
                }
            }
        }
        private static bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }
        private static bool AverageFilter(double mark)
        {
            return mark < 5.0 && mark >= 3.5;
        }
        private static bool PoorFilter(double mark)
        {
            return mark<3.5;
        }
        private static double Average(List<int>scoresOnTask)
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
