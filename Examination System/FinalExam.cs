using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        #region Constructor
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {

        }

        #endregion

        #region Methods
        public static FinalExam CreateFinalExam(int examTime, int numQuestions)
        {
            var exam = new FinalExam(examTime, numQuestions);
            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine("============== Final Exam ==============");
                Console.WriteLine($"Q{i+1}) Please choose the Type (1- MCQ | 2- True or False): ");
                int QuestionType;
                bool isVaildQuestionType = false;
                do
                {
                    isVaildQuestionType = int.TryParse(Console.ReadLine(), out QuestionType);
                    if (!isVaildQuestionType || (QuestionType != 1 && QuestionType != 2))
                    {
                        Console.WriteLine("[Invalid input] Please choose the Type (1- MCQ | 2- True or False) [Final Exam]: ");
                        isVaildQuestionType = false;
                    }
                    else
                    {
                        isVaildQuestionType = true;
                    }
                } while (!isVaildQuestionType);

                if (QuestionType == 1)
                {
                    exam.Questions[i] = McqQuestions.CreateMcqQuestion();
                    Console.Clear();
                }
                else if (QuestionType == 2)
                {
                    exam.Questions[i] = TrueFalseQuestion.CreateTFQuestion();
                    Console.Clear();
                }
            }
            return exam;
        }

        protected override void ProcessResults(Answer?[] studentAnswers, TimeSpan elapsed)
        {
            decimal studentGrade = 0;
            decimal totalMark = 0;

            Console.WriteLine("========== Final Exam Results ==========");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] == null) continue;

                Console.WriteLine($"Question {i + 1}: {Questions[i].Header}");
                Console.WriteLine($"Your Answer => {studentAnswers[i]?.AnswerText ?? "No Answer"}");
                Console.WriteLine($"Right Answer => {Questions[i].RightAnswer?.AnswerText ?? "N/A"}");

                totalMark += Questions[i].Mark;
                if (studentAnswers[i] != null && Questions[i].CheckAnswer(studentAnswers[i]))
                {
                    studentGrade += Questions[i].Mark;
                }
            }

            Console.WriteLine($"\nYour Grade is {studentGrade} from {totalMark}");
            Console.WriteLine($"Time = {elapsed}");
            Console.WriteLine("Thank you for taking the Final Exam!");
        }

        #endregion

    }
}
