using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Operations
    {
        public double First { get; set; }
        public double Second { get; set; }
        public string Operand { get; set; }
        public double CorrectAnswer { get; private set; }
        [Required(ErrorMessage = "Input answer")]
        public double Answer { get; set; }

        public Operations()
        {
            Random random = new Random();
            int First = random.Next(20);
            int Second = random.Next(20);
            string[] Operands = { "+", "-", "*", "/" };
            this.Operand = Operands[random.Next(4)];
            this.First = First;
            this.Second = Second;
        }
        public bool Check()
        {
            switch (Operand)
            {
                case "+":
                    CorrectAnswer = First + Second;
                    break;
                case "-":
                    CorrectAnswer = First - Second;
                    break;
                case "*":
                    CorrectAnswer = First * Second;
                    break;
                case "/":
                    if (this.Second == 0)
                    {
                        this.CorrectAnswer = 0;
                        break;
                    }
                    CorrectAnswer = (First / Second);
                    break;
            }
            if (Answer == CorrectAnswer)
            {
                return true;
            }
            return false;
        }
    }

    public sealed class CorrectAnswers
    {
        private CorrectAnswers()
        {
            Number = 0;
            Correct = 0;
            Total = 0;
            Answers = new List<Operations>();
        }
        
        public List<Operations> Answers;
        public int Correct { get; set; }
        public int Total { get; set; }
        public int Number { get; set; }

        public static CorrectAnswers Instance { get; } = new CorrectAnswers();

    }
}
