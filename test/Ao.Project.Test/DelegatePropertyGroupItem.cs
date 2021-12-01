using System;

namespace Ao.Project.Test
{
    internal class DelegatePropertyGroupItem : PropertyGroupItem
    {
        public DelegatePropertyGroupItem(Action decorateAction)
        {
            DecorateAction = decorateAction;
        }

        public Action DecorateAction { get; set; }

        public override void Decorate()
        {
            DecorateAction();
        }
    }
}
