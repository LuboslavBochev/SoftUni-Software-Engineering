using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students;

        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => this.students.AsReadOnly();

        public void AddModel(IStudent model) => this.students.Add(model);

        public IStudent FindById(int id) => this.students.FirstOrDefault(x => x.Id == id);

        public IStudent FindByName(string name)
        {
            string[] tokens = name.Split(" ");

            return this.students.FirstOrDefault(x => x.FirstName == tokens[0] && x.LastName == tokens[1]);
        }
    }
}
