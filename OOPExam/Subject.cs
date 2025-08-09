using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public class Subject
    {

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        public Subject(int subjectId, string sub_Name, Exam exam=null)
        {
            SubjectId = subjectId;
            SubjectName = sub_Name;
            Exam = exam;
        }

        public Subject(string sub_Name, int subjectId) : this(subjectId, sub_Name)
        {

        }

        public void EndPractical()
        {
            for(int i =0;i<Exam.NumberOfQuestions;i++)
            {
                Console.WriteLine($"Question {i+1}");
                //Console.WriteLine($"right answer {}");
            }
        }

        public void CreateExam()
        {
            Console.WriteLine($"Creating Exam for subject {SubjectName}");
            Console.WriteLine("----------------------------");
            int TypeOfExam;
            while (true)
            {
                Console.WriteLine("enter the type of exam 1(Practical) | 2 (Final)");
                if (int.TryParse(Console.ReadLine(), out TypeOfExam) && (TypeOfExam == 1 || TypeOfExam == 2))
                {
                    break; // valid input
                }
                Console.WriteLine("Please enter a valid input (1 or 2).");
            }
            int time;
            while (true)
            {
                Console.WriteLine("Enter exam time (30-60 minutes):");
                if (int.TryParse(Console.ReadLine(), out time) && time >= 30 && time <= 60)
                {
                    break;
                }
                Console.WriteLine("Invalid time! Please enter a number between 30 and 60.");
            }
            int numQuestions;
            while (true)
            {
                Console.WriteLine("Enter number of questions:");
                if (int.TryParse(Console.ReadLine(), out numQuestions) && numQuestions > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid number! Please enter a positive integer.");
            }

            if (TypeOfExam == 1)
            {
                Exam = new FinalExam(time, numQuestions);
                CreatePracticalExam();
            }
            else
            {
                Exam = new PracticalExam(time, numQuestions);
                CreateFinalExam();
            }
        }
        private void CreateFinalExam()
        {
            for (int i = 0; i < Exam.NumberOfQuestions; i++)
            {
                int questionType;
                while (true)
                {
                    Console.WriteLine("Enter type of question 1(MCQ) | 2(TrueOrFalse)");
                    if (int.TryParse(Console.ReadLine(), out questionType) && (questionType == 1 || questionType == 2))
                        break;
                    Console.WriteLine("Please enter a valid input (1 or 2).");
                }

                string header;
                do
                {
                    Console.WriteLine("Enter question's Header:");
                    header = Console.ReadLine()?.Trim() ?? string.Empty;
                    if (string.IsNullOrEmpty(header))
                        Console.WriteLine("Header cannot be empty. Please try again.");
                } while (string.IsNullOrEmpty(header));

                string body;
                do
                {
                    Console.WriteLine("Enter the question's Body:");
                    body = Console.ReadLine()?.Trim() ?? string.Empty;
                    if (string.IsNullOrEmpty(body))
                        Console.WriteLine("Body must not be empty. Please enter a valid input.");
                } while (string.IsNullOrEmpty(body));

                int mark;
                while (true)
                {
                    Console.WriteLine("Enter Question's Mark (positive integer):");
                    if (int.TryParse(Console.ReadLine(), out mark) && mark > 0)
                        break;
                    Console.WriteLine("Invalid mark. Please enter a positive integer.");
                }

                Question question;
                if (questionType == 1)
                {
                    var mcq = new MCQ(header, body, mark);
                    int numAnswers;
                    while (true)
                    {
                        Console.WriteLine("Enter number of answers (at least 2):");
                        if (int.TryParse(Console.ReadLine(), out numAnswers) && numAnswers >= 2)
                            break;
                        Console.WriteLine("Invalid number. Please enter at least 2.");
                    }

                    for (int j = 0; j < numAnswers; j++)
                    {
                        string answerText;
                        do
                        {
                            Console.WriteLine($"Enter answer {j + 1} text:");
                            answerText = Console.ReadLine()?.Trim() ?? string.Empty;
                            if (string.IsNullOrEmpty(answerText))
                                Console.WriteLine("Answer cannot be empty. Please try again.");
                        } while (string.IsNullOrEmpty(answerText));

                        mcq.AnswerList.Add(new Answer(j + 1, answerText));
                    }

                    int rightAnswer;
                    while (true)
                    {
                        Console.WriteLine("Enter the right answer number:");
                        if (int.TryParse(Console.ReadLine(), out rightAnswer) && rightAnswer >= 1 && rightAnswer <= numAnswers)
                            break;
                        Console.WriteLine($"Invalid choice. Please enter a number between 1 and {numAnswers}.");
                    }

                    mcq.RightAnswer = rightAnswer;
                    question = mcq;
                    Exam.AddQuestion(question);
                }
                else // TrueOrFalse
                {
                    var tof = new TrueOrFalse(header, body, mark);

                    int tf;
                    while (true)
                    {
                        Console.WriteLine("Enter the right answer 1(True) | 2(False):");
                        if (int.TryParse(Console.ReadLine(), out tf) && (tf == 1 || tf == 2))
                            break;
                        Console.WriteLine("Please enter 1 for True or 2 for False.");
                    }

                    tof.RightAnswer = tf; // adapt if your TrueOrFalse uses bool instead
                    question = tof;
                    Exam.AddQuestion(question); // <---- IMPORTANT: add it to the exam
                }
            }
        }

        private void CreatePracticalExam()
        {
            for (int i = 0; i < Exam.NumberOfQuestions; i++)
            {
                
                string header;
                do
                {
                    Console.WriteLine("Enter question's Header:");
                    header = Console.ReadLine()?.Trim() ?? string.Empty;
                    if (string.IsNullOrEmpty(header))
                        Console.WriteLine("Header cannot be empty. Please try again.");
                }
                while (string.IsNullOrEmpty(header));

                
                string body;
                do
                {
                    Console.WriteLine("Enter the question's Body:");
                    body = Console.ReadLine()?.Trim() ?? string.Empty;
                    if (string.IsNullOrEmpty(body))
                        Console.WriteLine("Body must not be empty. Please enter a valid input.");
                }
                while (string.IsNullOrEmpty(body));

                int mark;
                while (true)
                {
                    Console.WriteLine("Enter Question's Mark (positive integer):");
                    if (int.TryParse(Console.ReadLine(), out mark) && mark > 0)
                        break;
                    Console.WriteLine("Invalid mark. Please enter a positive integer.");
                }

                var question = new MCQ(header, body, mark);

                int numAnswers;
                while (true)
                {
                    Console.WriteLine("Enter number of answers (at least 2):");
                    if (int.TryParse(Console.ReadLine(), out numAnswers) && numAnswers >= 2)
                        break;
                    Console.WriteLine("Invalid number. Please enter at least 2.");
                }

                
                for (int j = 0; j < numAnswers; j++)
                {
                    string answerText;
                    do
                    {
                        Console.WriteLine($"Enter answer {j + 1} text:");
                        answerText = Console.ReadLine()?.Trim() ?? string.Empty;
                        if (string.IsNullOrEmpty(answerText))
                            Console.WriteLine("Answer cannot be empty. Please try again.");
                    }
                    while (string.IsNullOrEmpty(answerText));

                    question.AnswerList.Add(new Answer(j + 1, answerText));
                }
                int rightAnswer;
                while (true)
                {
                    Console.WriteLine("Enter the right answer number:");
                    if (int.TryParse(Console.ReadLine(), out rightAnswer) && rightAnswer >= 1 && rightAnswer <= numAnswers)
                        break;
                    Console.WriteLine($"Invalid choice. Please enter a number between 1 and {numAnswers}.");
                }
                question.RightAnswer = rightAnswer;

                Exam.AddQuestion(question);
            }
        }

    }
}
