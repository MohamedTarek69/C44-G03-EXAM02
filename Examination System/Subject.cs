using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {
        #region Properties & Attributes
        public int SubjectId { get; set; }

        public string? SubjectName { get; set; }

        private Exam? exam;

        #endregion

        #region Constructors
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Subject Name: {SubjectName}";
        }

        private static void EnterExamType (ref int type)
        {
            bool isVaildExamType = false;
            do
            {
                isVaildExamType = int.TryParse(Console.ReadLine(), out type);
                if (!isVaildExamType || (type != 1 && type != 2))
                {
                    Console.WriteLine("[Invalid input] Please choose the type of Exam (1- for Practical Or 2- for Final):");
                    isVaildExamType = false;
                }
                else
                {
                    isVaildExamType = true;
                }
            } while (!isVaildExamType);
        }

        private static void EnterExamTime(ref int time)
        {
            bool isVaildExamTime = false;
            do
            {
                isVaildExamTime = int.TryParse(Console.ReadLine(), out time);
                if (!isVaildExamTime || (time < 30 || time > 180))
                {
                    Console.WriteLine("[Invalid input] Please enter the time for the exam from 30 min to 180 min: ");
                    isVaildExamTime = false;
                }
                else
                {
                    isVaildExamTime = true;
                }
            } while (!isVaildExamTime);

        }

        private static void EnterNumberOfQuestions(ref int numberofquestions)
        {
            bool isVaildNumQuestions = false;
            do
            {
                isVaildNumQuestions = int.TryParse(Console.ReadLine(), out numberofquestions);
                if (!isVaildNumQuestions || (numberofquestions <= 0))
                {
                    Console.WriteLine("[Invalid input] Please Enter the Number of questions and it should be greater than 0:");
                    isVaildNumQuestions = false;
                }
                else
                {
                    isVaildNumQuestions = true;
                }
            } while (!isVaildNumQuestions);
        }

        public void CreateExam()
        {
            Console.WriteLine("Please choose the type of Exam (1- for Practical Or 2- for Final):");
            int ExamType = 0;
            EnterExamType(ref ExamType);

            Console.WriteLine("Please enter the time for the exam from 30 min to 180 min: ");
            int ExamTime = 0;
            EnterExamTime(ref ExamTime);

            Console.WriteLine("Please Enter the Number of questions:");
            int NumQuestions = 0;
            EnterNumberOfQuestions(ref NumQuestions);

            if (ExamType == 1)
            {
                exam = PracticalExam.CreatePracticalExam(ExamTime, NumQuestions);
            }
            else if (ExamType == 2)
            {
                exam = FinalExam.CreateFinalExam(ExamTime, NumQuestions);
            }

            Console.Clear();

            Console.WriteLine("Do you want to Start Exam (Y|N): ");
            string? StartExam;
            do
            {
                StartExam = Console.ReadLine()?.ToUpper();
                if (StartExam != "Y" && StartExam != "N")
                {
                    Console.WriteLine("[Invalid input] Do you want to Start Exam (Y|N): ");
                }
            } while (StartExam != "Y" && StartExam != "N");

            if (StartExam == "Y")
            {
                if (exam != null)
                {
                    Console.Clear();
                    exam.ShowExam();
                }
            }

        }

        #endregion

    }
}
