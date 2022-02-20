using System.Collections.Generic;
using System.Text;

namespace InterfacesAbstration
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps)
            :base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions { get => this.missions.AsReadOnly(); }

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.ToString());
            str.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                str.AppendLine("  " + mission);
            }

            return str.ToString().TrimEnd();
        }
    }
}
