
namespace Events
{
    using System;

    class EventRaiser
    {
        public event EventHandler<DelegateTypeEventArgs> DelegateTypeSelected;
        public event EventHandler ExecutionCompleted;

        // With delegate - public event DelegateTypeHandler DelegateTypeSelected;

        public void SelectDelegate()
        {
            foreach (var type in Enum.GetValues(typeof(DelegateType)))
            {
                DelegateType enumType = (DelegateType)Enum.Parse(typeof(DelegateType), type.ToString());
                OnDelegateType(enumType);
            }
        }

        protected virtual void OnDelegateType(DelegateType type)
        {
            DelegateTypeSelected?.Invoke(this, new DelegateTypeEventArgs(type));
        }

        protected virtual void OnCompleted(DelegateType type)
        {
            ExecutionCompleted?.Invoke(this, EventArgs.Empty);
        }
    }

    public enum DelegateType
    {
        SingleCast,
        MultiCast,
        Generic
    }
}
