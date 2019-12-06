using System;

namespace MvvmBasicPlus.Core.Helpers
{
    public class Messenger<TEvent> where TEvent : EventArgs
    {
        private static Messenger<TEvent> _m;

        public static Messenger<TEvent> Instance => _m ?? (_m = new Messenger<TEvent>());

        private Messenger()
        {
        }

        public event Action<object, TEvent> Event;

        public void Publish(object source, TEvent ev)
        {
            Event?.Invoke(source, ev);
        }
    }
}
