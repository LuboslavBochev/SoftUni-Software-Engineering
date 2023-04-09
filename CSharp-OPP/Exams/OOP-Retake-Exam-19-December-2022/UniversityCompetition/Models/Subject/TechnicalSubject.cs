using UniversityCompetition.Models;

namespace UniversityCompetition.Utilities
{
    public class TechnicalSubject : Subject
    {
        private const double subjectRate = 1.3;

        public TechnicalSubject(int subjectId, string subjectName)
            : base(subjectId, subjectName, subjectRate)
        {
        }

    }
}
