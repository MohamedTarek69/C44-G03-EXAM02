using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {
        #region Properties
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        protected Questions[] Questions { get; set; }

        #endregion

        #region Constructor
        public Exam(int time, int numberOfQuestions)
        {
            TimeOfExam = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Questions[numberOfQuestions];
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Time Of Exam: {TimeOfExam}, Number Of Questions: {NumberOfQuestions}";
        }

        public void ShowExam()
        {
            if (Questions == null || Questions.Length == 0)
            {
                Console.WriteLine("No questions available in this exam");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Answer?> studentAnswers = new List<Answer?>();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Clear();
                if (Questions[i] == null) continue;
                Questions[i].DisplayQuestion(i+1);
                Console.WriteLine("Please choose The right answer:");
                int answerId;
                bool isValidAnswer = false;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out answerId))
                    {
                        if (answerId > 0 && answerId <= Questions[i]?.AnswersList?.Length)
                        {
                            isValidAnswer = true;
                        }
                        else
                        {
                            Console.WriteLine("[Invalid answer] Please choose The right answer:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input Please choose The right answer:");
                    }
                } while (!isValidAnswer);

                Answer? chosenAnswer = null;
                var answersList = Questions[i]?.AnswersList;

                if (answersList != null)
                {
                    foreach (var answer in answersList) 
                    {
                        if (answer?.AnswerId == answerId)
                        {
                            chosenAnswer = answer;
                            break;
                        }
                    }
                }
                studentAnswers.Add(chosenAnswer);
            }

            stopwatch.Stop();
            Console.Clear();

            ProcessResults(studentAnswers.ToArray(), stopwatch.Elapsed);
        }

        protected abstract void ProcessResults(Answer?[] studentAnswers, TimeSpan elapsed);

        #endregion

    }
}
