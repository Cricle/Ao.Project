using System.Collections.Generic;

namespace Ao.Project
{
    public sealed class PropertyGroup : ProjectPartGroup<IPropertyGroupItem>, IPropertyGroupItem
    {
        public PropertyGroup()
        {
        }

        public PropertyGroup(IEnumerable<IPropertyGroupItem> datas) : base(datas)
        {
        }

        public void Decorate(IProject project)
        {
            foreach (var item in Items)
            {
                item.Decorate(project);
            }
        }
    }
}
