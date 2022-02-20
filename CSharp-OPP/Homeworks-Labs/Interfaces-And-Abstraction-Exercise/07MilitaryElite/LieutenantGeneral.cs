using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesAbstration
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates { get => this.privates.AsReadOnly(); }

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.ToString());
            str.AppendLine("Privates:");

            foreach (var @private in this.Privates)
            {
                str.AppendLine("  " + @private);
            }

            return str.ToString().TrimEnd();
        }
    }
}
