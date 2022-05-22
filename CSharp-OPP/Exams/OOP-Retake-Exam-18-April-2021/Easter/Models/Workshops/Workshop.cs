using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            bool isValid = bunny.Dyes.Count != 0 && bunny.Energy != 0;
            List<IDye> dyes = bunny.Dyes.ToList();

            if (isValid)
            {
                for (int i = 0; i < dyes.Count; i++)
                {
                    while (!dyes[i].IsFinished())
                    {
                        if (egg.IsDone() || bunny.Energy == 0) return;
                        dyes[i].Use();
                        bunny.Work();
                        egg.GetColored();
                    }
                    bunny.Dyes.Remove(dyes[i]);
                }
            }
        }
    }
}
