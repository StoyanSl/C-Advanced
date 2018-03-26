
using BashSoftProgram.Exceptions;

namespace BashSoftProgram.IO.Commands
{
    class ShowCourseCommand:Command
    {
        public ShowCourseCommand(string input, string[] data, Tester tester, StudentRepository repo, IOManager iOManager) : base(input, data, tester, repo, iOManager)
        {

        }
        public override void Execute()
        {
            if (Data.Length == 1)
            {
                Repo.ShowWholeData();
            }
            else if (Data.Length == 2)
            {
                string courseName = Data[1];
                Repo.GetAllStudentsFromCourse(courseName);
            }
            else if (Data.Length == 3)
            {
                string courseName = Data[1];
                string userName = Data[2];
                Repo.GetStudentScoresFromCourse(courseName, userName);

            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
