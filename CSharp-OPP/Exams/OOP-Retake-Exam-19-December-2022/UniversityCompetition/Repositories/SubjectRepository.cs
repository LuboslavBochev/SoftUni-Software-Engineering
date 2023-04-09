﻿using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> subjects;

        public SubjectRepository()
        {
            this.subjects = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => this.subjects.AsReadOnly();

        public void AddModel(ISubject model) => this.subjects.Add(model);

        public ISubject FindById(int id) => this.subjects.FirstOrDefault(x => x.Id == id);

        public ISubject FindByName(string name) => this.subjects.FirstOrDefault(x => x.Name == name);
    }
}
