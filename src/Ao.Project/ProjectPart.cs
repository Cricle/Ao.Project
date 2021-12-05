namespace Ao.Project
{
    public abstract class ProjectPart : IProjectPart
    {
        public ProjectPart()
        {
        }

        public virtual void Reset()
        {
        }
        protected virtual void OnProjectChanged(IProject project)
        {

        }
    }
}
