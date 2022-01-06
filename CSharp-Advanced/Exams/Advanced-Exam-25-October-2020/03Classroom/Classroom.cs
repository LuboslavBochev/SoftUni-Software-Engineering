using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; private set; }

        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > 0)
            {
                this.Capacity--;
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = this.students.Find(student => student.FirstName == firstName && student.LastName == lastName);

            if (student != null)
            {
                this.students.Remove(student);
                this.Capacity++;
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder str = new StringBuilder();

            if (this.students.Exists(student => student.Subject == subject))
            {
                str.AppendLine($"Subject: {subject}");
                str.AppendLine("Students: ");

                foreach (var student in this.students)
                {
                    if (student.Subject == subject)
                    {
                        str.AppendLine($"{student.FirstName} {student.LastName}");
                    }
                }
                return str.ToString().TrimEnd();
            }
            else return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.Find(student => student.FirstName == firstName && student.LastName == lastName);
        }
    }
}
