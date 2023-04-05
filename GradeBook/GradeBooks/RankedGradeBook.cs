using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            List<double> oceny = new List<double>();

            foreach (var student in Students)
            {
                oceny.AddRange(student.Grades);
            }

            oceny.Sort();

            double top20 = oceny[(int)Math.Ceiling(oceny.Count * 0.2)];

            double top40 = oceny[(int)Math.Ceiling(oceny.Count * 0.4)];

            double top60 = oceny[(int)Math.Ceiling(oceny.Count * 0.6)];

            double top80 = oceny[(int)Math.Ceiling(oceny.Count * 0.8)];


            if (top20 < averageGrade)
                return 'A';
            else if (top40 < averageGrade)
                return 'B';
            else if (top60 < averageGrade)
                return 'C';
            else if (top80 < averageGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            base.CalculateStatistics(); 
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
