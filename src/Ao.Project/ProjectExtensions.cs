using System;
using System.Collections.Generic;
using System.Linq;

namespace Ao.Project
{
    public static class ProjectExtensions
    {
        public static IEnumerable<IItemGroupPart> FindItemGroupParts(this IProject project, Predicate<IItemGroupPart> condition)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (condition(project))
            {
                yield return project;
            }
            IEnumerable<IItemGroupPart> targets = project.ItemGroups;
            while (targets.Any())
            {
                foreach (var item in targets)
                {
                    if (condition(item))
                    {
                        yield return item;
                    }
                }
                targets = targets.OfType<ItemGroup>().SelectMany(x => x.Items);
            }
        }
        public static IEnumerable<IItemGroupPart> FindItemGroupParts(this IProject project, Type type)
        {
            return FindItemGroupParts(project, p => p.GetType()==type);
        }
        public static IEnumerable<T> FindItemGroupParts<T>(this IProject project)
            where T : ItemGroupPart
        {
            return FindItemGroupParts(project, typeof(T)).OfType<T>();
        }
        public static IProjectSkeleton ToSkeleton(this IProject project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            return new ProjectSkeleton
            {
                ItemGroup = new ItemGroup(project.ItemGroups),
                PropertyGroup = new PropertyGroup(project.PropertyGroups)
            };
        }
    }
}
