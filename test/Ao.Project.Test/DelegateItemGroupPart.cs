using System;
using System.Threading.Tasks;

namespace Ao.Project.Test
{
    internal class DelegateItemGroupPart : ItemGroupPart
    {
        public static readonly Func<Task> Empty = () => Task.FromResult(1);
        public DelegateItemGroupPart(Func<Task> action)
        {
            Action = action;
        }
        public DelegateItemGroupPart(Action action)
        {
            Action = () =>
            {
                action();
                return Task.FromResult(0);
            };
        }

        public Func<Task> Action { get; }

        public Action DisposeAction { get; set; }

        public override Task ConductAsync()
        {
            return Action();
        }
        public override void Dispose()
        {
            DisposeAction();
        }
    }
}
