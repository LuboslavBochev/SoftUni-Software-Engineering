using System.Collections.Generic;
using System.Text;

namespace InterfacesAbstration
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;

        public Engineer(string id,
            string firstName,
            string lastName,
            decimal salary,
            Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs { get => this.repairs.AsReadOnly(); }

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.ToString());
            str.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                str.AppendLine("  " + repair);
            }

            return str.ToString().TrimEnd();
        }
    }
}
