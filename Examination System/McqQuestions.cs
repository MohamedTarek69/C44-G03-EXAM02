using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class McqQuestions : Questions
    {
        #region Constructor
        public McqQuestions(string header, decimal mark)
        {
            Header = header;
            Mark = mark;
        }

        #endregion

        #region Methods
        public override void DisplayQuestion(int numberOfQuestion)
        {
            Console.WriteLine($"MCQ Question--------------Mark {Mark}:");
            Console.WriteLine($"Q{numberOfQuestion}: {Header} ");
            Console.WriteLine("Choices: ");
            foreach (var answer in AnswersList)
            {
                Console.WriteLine($"{answer.AnswerId}-{answer.AnswerText}");
            }
        }

        public static McqQuestions CreateMcqQuestion()
        {
            Console.WriteLine("Please enter question body:");
            string? Body = string.Empty;
            
            AddBody(ref Body);

            Console.WriteLine("Please enter question mark:");
            decimal Mark = 0;
            
            AddMark(ref Mark);

            McqQuestions Mcq = new McqQuestions(Body, Mark);

            Console.WriteLine("choices of question:");
            Mcq.AnswersList = new Answer[3];
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"Please enter the body of choice number {j + 1}:");
                string? ChoiceText = string.Empty;
                do
                {
                    ChoiceText = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ChoiceText))
                    {
                        Console.WriteLine($"[Invalid input] Please enter the body of choice number {j + 1}: ");
                    }
                } while (string.IsNullOrWhiteSpace(ChoiceText));
                Mcq.AnswersList[j] = new Answer(j+1, ChoiceText);
            }

            int RightAnswerId = 0;

            Console.WriteLine("Please choose the right answer: ");
            bool isVaildRightAnswerId = false;
            do
            {
                isVaildRightAnswerId = int.TryParse(Console.ReadLine(), out RightAnswerId);
                if (!isVaildRightAnswerId || (RightAnswerId < 1 || RightAnswerId > 3))
                {
                    Console.WriteLine("[Invalid input] Please choose the right answer (1 , 2 , 3): ");
                    isVaildRightAnswerId = false;
                }
            } while (!isVaildRightAnswerId);

            Answer? CorrectMcqAnswer = null;

            foreach (var ans in Mcq.AnswersList)
            {
                if (ans.AnswerId == RightAnswerId)
                {
                    CorrectMcqAnswer = ans;
                    break;
                }
            }
            
            Mcq.RightAnswer = CorrectMcqAnswer;

            return Mcq;
        }

        #endregion


    }
}
