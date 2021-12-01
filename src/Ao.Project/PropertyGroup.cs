namespace Ao.Project
{
    public sealed class PropertyGroup : ProjectPartGroup<IPropertyGroupItem>, IPropertyGroupItem
    {
        public void Decorate()
        {
            foreach (var item in Items)
            {
                item.Decorate();
            }
        }
    }
}
