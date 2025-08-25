using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TrueFalseQuestion : Questions
    {
        #region Constructor
        public TrueFalseQuestion(string header, decimal mark)
        {
            Header = header;
            Mark = mark;
            AnswersList = new Answer[]
            {
            new Answer(1 , "True"),
            new Answer(2 , "False")
            };
        }

        #endregion

        #region Methods
        public override void DisplayQuestion(int numberOfQuestion)
        {
            Console.WriteLine($"True or False Question--------------Mark {Mark}:");
            Console.WriteLine($"Q{numberOfQuestion}: {Header} ");
            Console.WriteLine("Choices: ");
            foreach (var answer in AnswersList)
            {
                Console.WriteLine($"{answer.AnswerId}-{answer.AnswerText}");
            }
        }

        public static TrueFalseQuestion CreateTFQuestion()
        {
            Console.WriteLine("True or False Question: ");
            Console.WriteLine("Please Enter Question Body:");
            string? Body = string.Empty;
            AddBody(ref Body);

            Console.WriteLine("Please Enter Question Mark:");
            decimal Mark = 0;
            AddMark(ref Mark);

            TrueFalseQuestion TF = new TrueFalseQuestion(Body, Mark);

            Console.WriteLine("Please choose the right answer (1- true or 2- false):");
            int RightAnswerId;
            bool isVaildRightAnswerId = false;
            do
            {
                isVaildRightAnswerId = int.TryParse(Console.ReadLine(), out RightAnswerId);
                if (!isVaildRightAnswerId || (RightAnswerId != 1 && RightAnswerId != 2))
                {
                    Console.WriteLine("[Invalid input] Please choose the right answer id (1- true , 2- false):");
                    isVaildRightAnswerId = false;
                }
            } while (!isVaildRightAnswerId);

            Answer? CorrectTfAnswer = null;
            foreach (var ans in TF.AnswersList)
            {
                if (ans.AnswerId == RightAnswerId)
                {
                    CorrectTfAnswer = ans;
                    break;
                }
            }
            TF.RightAnswer = CorrectTfAnswer;

            return TF;
        }

        #endregion
    }
}
