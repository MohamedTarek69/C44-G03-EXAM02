namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1,"C# Exam");
            subject.CreateExam();
        }
    }
}
