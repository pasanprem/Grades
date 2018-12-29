using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }

            

            catch(ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            catch(NullReferenceException)
            {
                Console.WriteLine("Something went wrong!");
            }  

                       
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }

            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest",stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }
       
        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }
    }
}
