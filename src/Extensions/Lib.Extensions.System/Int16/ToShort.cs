using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int32 ToInt32(this Int16 intVal)
            => Convert.ToInt32(intVal);
}
