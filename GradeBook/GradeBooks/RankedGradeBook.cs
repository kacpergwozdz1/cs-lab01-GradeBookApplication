using GradeBook.Enums;
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
        Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {

                throw new InvalidOperationException(" You must have at least 5 students to do ranked grading");

            }

            var howManyStud = (int)Math.Ceiling(Students.Count * 0.2); // .1
            var minGrade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList(); // !!!!!!!

            if (averageGrade >= minGrade[howManyStud - 1])
                return 'A';

            if (averageGrade >= minGrade[(howManyStud * 2) - 1]) // nie mozna z int na double <!=
                return 'B';

            if (averageGrade >= minGrade[(howManyStud * 3) - 1])
                return 'C';

            if (averageGrade >= minGrade[(howManyStud * 4) - 1])
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)    Console.WriteLine("Ranked grading requires at least 5 students.");
            else                       base.CalculateStatistics();
        }

            public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)    Console.WriteLine("Ranked grading requires at least 5 students.");
            else                       base.CalculateStudentStatistics(name);
        }

    }

}
