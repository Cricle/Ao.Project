using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Ao.Project
{
    public abstract class ProjectPartGroup<T> : ProjectPart
        where T : IProjectPart
    {

        public ObservableCollection<T> Items { get; }

        public ProjectPartGroup()
        {
            Items = new ObservableCollection<T>();
        }
    }
}
