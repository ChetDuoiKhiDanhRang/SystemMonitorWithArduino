using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemMonitorWithArduino
{
    public delegate void ValueChangedHandler<T>(object sender, ValueChangedArguments<T> e);
    public class ValueChangedArguments<T>
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
    }
}
