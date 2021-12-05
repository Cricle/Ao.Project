using System.Threading.Tasks;

namespace Ao.Project
{
    public abstract class ItemGroupPart : ProjectPart, IItemGroupPart
    {
        public abstract Task ConductAsync(IProject project);

        public virtual void Dispose()
        {
        }

    }
}
