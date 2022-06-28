using System.Collections.Generic;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> formulaOneCars = new List<IFormulaOneCar>();

        public IReadOnlyCollection<IFormulaOneCar> Models => this.formulaOneCars.AsReadOnly();

        public void Add(IFormulaOneCar model) => this.formulaOneCars.Add(model);

        public IFormulaOneCar FindByName(string name) => this.formulaOneCars.FirstOrDefault(c => c.Model == name);

        public bool Remove(IFormulaOneCar model) => this.formulaOneCars.Remove(model);
    }
}
