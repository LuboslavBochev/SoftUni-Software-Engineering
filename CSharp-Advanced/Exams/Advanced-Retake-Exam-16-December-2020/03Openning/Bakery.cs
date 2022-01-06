using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.employees = new List<Employee>();
        }

        public IReadOnlyCollection<Employee> Employees => this.employees.AsReadOnly();

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count { get => this.employees.Count; }

        public void Add(Employee employee)
        {
            if(this.Capacity > 0)
            {
                this.employees.Add(employee);
                this.Capacity--;
            }
        }

        public bool Remove(string name)
        {
            Employee employee = this.employees.Find(emp => emp.Name == name);

            if(employee != null)
            {
                this.employees.Remove(employee);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return this.employees.OrderByDescending(emp => emp.Age).First();
        }

        public Employee GetEmployee(string name)
        {
            return this.employees.Find(emp => emp.Name == name);
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.employees)
            {
                str.AppendLine(employee.ToString());
            }
            return str.ToString().TrimEnd();
        }
    }
}
