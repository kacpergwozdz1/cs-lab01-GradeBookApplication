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

                throw new InvalidOperationException("You must have at least 5 students to do ranked grading");

            }

            var howManyStud = (int)(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[howManyStud - 1])
                return 'A';
            if (averageGrade >= grades[(howManyStud * 2) - 1])
                return 'B';
            if (averageGrade >= grades[(howManyStud * 3) - 1])
                return 'C';
            if (averageGrade >= grades[(howManyStud * 4) - 1])
                return 'D';
            return 'F';
        }

    }

}
