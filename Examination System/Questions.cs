using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Questions
    {
        #region Properties
        public string? Header { get; set; }
        public string? Body { get; set; }
        public decimal Mark { get; set; }
        public Answer[]? AnswersList { get; set; }
        public Answer? RightAnswer { get; set; }

        #endregion

        #region Methods
        public abstract void DisplayQuestion(int numberOfQuestion);

        public override string ToString()
        {
            return $"Question: {Header}, Mark: {Mark}";
        }

        public bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.AnswerId == RightAnswer?.AnswerId;
        }

        protected static void AddBody(ref string? body)
        {
            do
            {
                body = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(body))
                {
                    Console.WriteLine("[Invalid input] Please enter question body: ");
                }
            } while (string.IsNullOrWhiteSpace(body));
        }

        protected static void AddMark(ref decimal mark)
        {
            bool isVaildMark = false;
            do
            {
                isVaildMark = decimal.TryParse(Console.ReadLine(), out mark);
                if (!isVaildMark || (mark <= 0))
                {
                    Console.WriteLine("[Invalid input] Please Enter Question Mark and it should be greater than 0: ");
                    isVaildMark = false;
                }
            } while (!isVaildMark);
        }

        #endregion
    }
}
