using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Ao.Project
{
    public abstract class ProjectPartGroup<T> : ProjectPart, IList<T>, IEnumerable<T>, INotifyCollectionChanged, INotifyPropertyChanged
        where T : IProjectPart
    {
        public ProjectPartGroup()
        {
            Items = new ObservableCollection<T>();

        }
        public ProjectPartGroup(IEnumerable<T> datas)
        {
            if (datas is null)
            {
                throw new ArgumentNullException(nameof(datas));
            }

            Items = new ObservableCollection<T>(datas);
        }

        public T this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }

        public ObservableCollection<T> Items { get; }

        public int Count => Items.Count;

        bool ICollection<T>.IsReadOnly => false;

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { Items.CollectionChanged+=value; }
            remove { Items.CollectionChanged-=value; }
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { ((INotifyPropertyChanged)Items).PropertyChanged += value; }
            remove { ((INotifyPropertyChanged)Items).PropertyChanged -= value; }
        }

        public void Add(T item)
        {
            Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool Contains(T item)
        {
            return Items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return Items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Items.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return Items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            return Items.ToString();
        }
    }
}
