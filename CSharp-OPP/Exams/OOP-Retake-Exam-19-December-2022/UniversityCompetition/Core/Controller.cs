using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Student;
using UniversityCompetition.Models.University;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly SubjectRepository subjects;
        private readonly StudentRepository students;
        private readonly UniversityRepository universities;
        private int subjectCounter = 1;
        private int universityCounter = 1;
        private int studentCounter = 1;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (this.students.FindByName(firstName + " " + lastName) != null) return $"{firstName} {lastName} is already added in the repository.";

            IStudent student = new Student(this.studentCounter++, firstName, lastName);
            this.students.AddModel(student);

            return $"Student {firstName} {lastName} is added to the {this.students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject;

            if (this.subjects.FindByName(subjectName) != null) return $"{subjectName} is already added in the repository.";

            switch (subjectType)
            {
                case "EconomicalSubject":
                    subject = new EconomicalSubject(this.subjectCounter++, subjectName);
                    break;

                case "HumanitySubject":
                    subject = new HumanitySubject(this.subjectCounter++, subjectName);
                    break;

                case "TechnicalSubject":
                    subject = new TechnicalSubject(this.subjectCounter++, subjectName);
                    break;

                default:
                    return $"Subject type {subjectType} is not available in the application!";
            }
            this.subjects.AddModel(subject);
            return $"{subjectType} {subjectName} is created and added to the {this.subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            List<int> convertedSubj = new List<int>();

            foreach (var subj in requiredSubjects)
            {
                ISubject subject = this.subjects.FindByName(subj);

                if (subject != null) convertedSubj.Add(subject.Id);
            }

            if (this.universities.FindByName(universityName) != null) return $"{universityName} is already added in the repository.";

            IUniversity university = new University(this.universityCounter++, universityName, category, capacity, convertedSubj);
            this.universities.AddModel(university);

            return $"{universityName} university is created and added to the {this.universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] parts = studentName.Split(" ");
            string firstName = parts[0];
            string lastName = parts[1];
            IStudent student = this.students.FindByName(studentName);
            IUniversity university = this.universities.FindByName(universityName);

            if (student == null) return $"{firstName} {lastName} is not registered in the application!";
            if (university == null) return $"{universityName} is not registered in the application!";

            bool allExamsPassed = true;

            foreach (var exam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Any(x => x == exam))
                {
                    allExamsPassed = false;
                    break;
                }
            }
            if (!allExamsPassed) return $"{studentName} has not covered all the required exams for {universityName} university!";
            if (student.University != null)
            {
                if (student.University.Name == university.Name)
                {
                    return $"{firstName} {lastName} has already joined {university.Name}.";
                }
            }
            student.JoinUniversity(university);
            return $"{firstName} {lastName} joined {universityName} university!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (this.students.FindById(studentId) == null) return "Invalid student ID!";
            if (this.subjects.FindById(subjectId) == null) return "Invalid subject ID!";

            IStudent student = this.students.FindById(studentId);
            ISubject subject = this.subjects.FindById(subjectId);

            if (student.CoveredExams.FirstOrDefault(x => x == subjectId) != 0)
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";
            }

            student.CoverExam(subject);
            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = this.universities.FindById(universityId);

            int allStudentsAdmitted = this.students.Models.Where(x => x.University != null).Count(x => x.University.Id == universityId);

            StringBuilder str = new StringBuilder();

            str.AppendLine($"*** {university.Name} ***");
            str.AppendLine($"Profile: {university.Category}");
            str.AppendLine($"Students admitted: {allStudentsAdmitted}");
            str.AppendLine($"University vacancy: {university.Capacity - allStudentsAdmitted}");

            return str.ToString().TrimEnd();
        }
    }
}
