using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public abstract class Exam
    {
        public int Time { get; set; } // in minutes
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public int[] StudentAnswers { get; set; }
        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
            StudentAnswers = new int[numberOfQuestions];
        }
        public abstract  void ShowExam();

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public int GradeCalc()
        {
            int grade = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                if (StudentAnswers[i] == Questions[i].RightAnswer)
                {
                    grade += Questions[i].Mark;
                }
            }
            return grade;
        }

    }
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam: {Time} minutes, {NumberOfQuestions} questions");

            // Display questions first
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }

            StudentAnswers = new int[Questions.Count];

            for (int i = 0; i < Questions.Count; i++)
            {
                Questions[i].DisplayQuestion();
                Console.WriteLine("your answer (option number)");
                int answer;
                bool IsParse = int.TryParse(Console.ReadLine(), out answer);
                if (IsParse && answer > 0 && answer <= Questions[i].AnswerList.Count)
                {
                    StudentAnswers[i] = answer;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid option number.");
                    i--; // re-ask the same question
                }
            }

            Console.WriteLine("\nExam Finished! Here are your results:");
            int grade = 0;
            int totalMarks = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                totalMarks += Questions[i].Mark;
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Your answer: {Questions[i].AnswerList[StudentAnswers[i] - 1].AnswerText}");
                Console.WriteLine($"Correct answer: {Questions[i].AnswerList[Questions[i].RightAnswer - 1].AnswerText}");
                if (StudentAnswers[i] == Questions[i].RightAnswer)
                {
                    grade += Questions[i].Mark;
                }
            }
            Console.WriteLine(GradeCalc());
            Console.WriteLine($"\nYour total grade: {grade} / {totalMarks}");
        }
    }

    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine($"Practical Exam - Time: {Time} minutes, Questions: {NumberOfQuestions}");
            for (int i = 0; i < Questions.Count; i++)
            {
                Questions[i].DisplayQuestion();
                Console.WriteLine("your answer (option number)");
                int answer;
                bool IsParse = int.TryParse(Console.ReadLine(), out answer);
                if (IsParse && answer > 0 && answer <= Questions[i].AnswerList.Count)
                {
                    StudentAnswers[i] = answer;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid option number.");
                    i--;
                }
            }

            Console.WriteLine("\nExam Finished! Here are your results:");

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Correct answer: {Questions[i].AnswerList[Questions[i].RightAnswer - 1].AnswerText}");
            }
        }
    }
}
