using System.Threading.Tasks;

namespace Ao.Project
{
    public sealed class ItemGroup : ProjectPartGroup<IItemGroupPart>, IItemGroupPart
    {
        public async Task ConductAsync()
        {
            foreach (var item in Items)
            {
                await item.ConductAsync();
            }
        }

        public void Dispose()
        {
            foreach (var item in Items)
            {
                item.Dispose();
            }
        }
    }
}
