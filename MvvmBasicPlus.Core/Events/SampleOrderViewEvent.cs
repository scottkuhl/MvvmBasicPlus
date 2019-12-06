using System;

namespace MvvmBasicPlus.Core.Events
{
    public class SampleOrderViewEvent : EventArgs
    {
        public string Name { get; set; }
    }
}
