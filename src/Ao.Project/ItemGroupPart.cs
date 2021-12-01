using System.Threading.Tasks;

namespace Ao.Project
{
    public abstract class ItemGroupPart : ProjectPart, IItemGroupPart
    {
        public abstract Task ConductAsync();

        public virtual void Dispose()
        {
        }

    }
}
