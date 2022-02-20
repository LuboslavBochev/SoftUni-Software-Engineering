using System.Collections.Generic;

namespace InterfacesAbstration
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }

        public void AddPrivate(IPrivate @private);
    }
}
