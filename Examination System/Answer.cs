using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Answer
    {
        #region Properties
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }

        #endregion

        #region Constructors
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Answer ID: {AnswerId}, Answer Text: {AnswerText}";
        }

        #endregion
    }
}
