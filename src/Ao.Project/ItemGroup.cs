using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ao.Project
{
    public sealed class ItemGroup : ProjectPartGroup<IItemGroupPart>, IItemGroupPart
    {
        public ItemGroup()
        {
        }

        public ItemGroup(IEnumerable<IItemGroupPart> datas) : base(datas)
        {
        }

        public async Task ConductAsync(IProject project)
        {
            foreach (var item in Items)
            {
                await item.ConductAsync(project);
            }
        }
        public override void Initialize(IServiceProvider provider)
        {
            foreach (var item in Items)
            {
                item.Initialize(provider);
            }
            base.Initialize(provider);
        }
        public override void Dispose()
        {
            foreach (var item in Items)
            {
                item.Dispose();
            }
        }
    }
}
