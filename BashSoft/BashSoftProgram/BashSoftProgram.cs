using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoftProgram
{
    public class BashSoftProgram
    {
        public static void Main()
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoresFromCourse("Unity","Ivan");

        }
    }
}
