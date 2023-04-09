using UniversityCompetition.Models;

namespace UniversityCompetition.Utilities
{
    public class HumanitySubject : Subject
    {
        private const double subjectRate = 1.0;

        public HumanitySubject(int subjectId, string subjectName)
            : base(subjectId, subjectName, subjectRate)
        {
        }
    }
}
