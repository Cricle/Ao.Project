using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Ao.Project
{
    public abstract class ProjectPartGroup<T> : ProjectPart
        where T : IProjectPart
    {
        public ProjectPartGroup()
        {
            Items = new ObservableCollection<T>();

        }
        public ProjectPartGroup(IEnumerable<T> datas)
        {
            Items = new ObservableCollection<T>(datas);
        }
        public ObservableCollection<T> Items { get; }

    }
}
