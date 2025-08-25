using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        #region Constructor
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) 
        {
            
        }

        #endregion

        #region Methods
        public static PracticalExam CreatePracticalExam(int examTime, int numQuestions)
        {
            var exam = new PracticalExam(examTime, numQuestions);
            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine("============== Practical Exam ==============");
                Console.WriteLine("MCQ Question:");
                Console.WriteLine($"Q{i + 1}):");
                exam.Questions[i] = McqQuestions.CreateMcqQuestion();
            }
            return exam;
        }

        protected override void ProcessResults(Answer?[] studentAnswers, TimeSpan elapsed)
        {
            Console.WriteLine("========== Practical Exam Results ==========");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] == null) continue;

                Console.WriteLine($"Question {i + 1}: {Questions[i].Header}");
                Console.WriteLine($"Your Answer => {studentAnswers[i]?.AnswerText ?? "No Answer"}");
                Console.WriteLine($"Right Answer => {Questions[i].RightAnswer?.AnswerText ?? "N/A"}");
            }

            Console.WriteLine($"\nTime = {elapsed}");
            Console.WriteLine("Thank you for taking the Practical Exam!");
        }
        #endregion

    }
}
