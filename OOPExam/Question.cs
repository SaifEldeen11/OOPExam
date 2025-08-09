using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public int RightAnswer { get; set; }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new List<Answer>();
        }

        public abstract void DisplayQuestion();
    }
    public class TrueOrFalse:Question
    {
        public TrueOrFalse(string header, string body, int mark): base(header, body, mark)
        {
            AnswerList.Add(new Answer(1, "True"));
            AnswerList.Add(new Answer(2, "False"));
        }
        public override void DisplayQuestion()
        {
            Console.WriteLine($"True/False {Header}");
            Console.WriteLine(Body);
            Console.WriteLine("1.True");
            Console.WriteLine("2.False");

        }
    }
    public class MCQ:Question
    {
        public MCQ(string header, string body, int mark): base(header, body, mark) { }
        public override void DisplayQuestion()
        {
            Console.WriteLine($"MCQ {Header}");
            Console.WriteLine(Body);
            for(int i=0;i<AnswerList.Count;i++)
            {
                Console.WriteLine($"{i + 1}. {AnswerList[i].AnswerText}");
            }
        }
    }
}
