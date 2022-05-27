using System;

namespace Ao.Project
{
    public abstract class ProjectPart : IProjectPart
    {
        public ProjectPart()
        {
        }

        public virtual void Dispose()
        {
        }

        public virtual void Initialize(IServiceProvider provider)
        {
        }

        public virtual void Reset()
        {
        }
    }
}
