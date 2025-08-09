namespace OOPExam
{
    /*NOTE*/
    // the code prints the grade in the practical exam instead of the final exam
    // even though there is no code to calculate the grade in the practical exam
    // so it might be a glitch but there is no code in the practical exam to calculate the grade

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Examination System");
            Console.WriteLine("------------------");

            // Get subject name
            Console.WriteLine("Enter subject name");
            string subjectName;
            while (true)
            {
                subjectName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(subjectName))
                {
                    break; // valid input
                }
                Console.WriteLine("Please enter a valid subject name.");
            }

            // Get subject ID
            int SubjectId;
            while (true)
            {
                Console.WriteLine("Enter subject ID (positive integer):");
                if (int.TryParse(Console.ReadLine(), out SubjectId) && SubjectId > 0)
                {
                    break; // valid input
                }
                Console.WriteLine("Invalid ID! Please enter a positive integer.");
            }

            // Create subject and exam
            Subject subject = new Subject(SubjectId, subjectName);
            subject.CreateExam();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine();
            subject.Exam.ShowExam(); 

        }
    }
}
